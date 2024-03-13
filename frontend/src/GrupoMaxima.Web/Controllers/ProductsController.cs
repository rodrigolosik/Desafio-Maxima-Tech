using Application.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GrupoMaxima.Web.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductService _productService;
    private readonly IDepartmentService _departmentService;

    public ProductsController(ILogger<ProductsController> logger, IProductService productService, IDepartmentService departmentService)
    {
        _logger = logger;
        _productService = productService;
        _departmentService = departmentService;
    }

    public async Task<ActionResult> Index()
    {
        var products = await _productService.GetAllAsync();

        return View(products);
    }

    public async Task<ActionResult> CreateOrEdit(Guid? id)
    {
        var productViewModel = new CreateOrUpdateProductViewModel();

        var departments = await _departmentService.GetAllAsync();

        productViewModel.DepartmentViewModel = departments;

        if (id != null && id != Guid.Empty)
        {
            var product = await _productService.GetByIdAsync(id.Value);
            
            productViewModel.ProductViewModel = product;
            productViewModel.ProductId = id.Value;
        }

        return View(productViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Save(CreateOrUpdateProductViewModel viewModel)
    {
        try
        {
            if(viewModel.ProductViewModel?.Id == Guid.Empty)
            {
                await _productService.CreateAsync(viewModel.ProductViewModel);
            }
            else
            {
                await _productService.UpdateAsync(viewModel.ProductViewModel);
            }

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View("CreateOrEdit", viewModel);
        }
    }
}
