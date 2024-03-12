namespace Domain.ViewModels;

public class CreateOrUpdateProductViewModel
{
    public ProductViewModel? ProductViewModel { get; set; }
    public IEnumerable<DepartmentViewModel> DepartmentViewModel { get; set; }
}
