namespace Domain.ViewModels;

public class CreateOrUpdateProductViewModel
{
    public Guid ProductId { get; set; }
    public ProductViewModel? ProductViewModel { get; set; }
    public IEnumerable<DepartmentViewModel> DepartmentViewModel { get; set; }
}
