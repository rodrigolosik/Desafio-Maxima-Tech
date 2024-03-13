namespace Domain.Dtos.Products;

public class RequestProductDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Guid DepartmentId { get; set; }
    public string Department { get; set; }
    public decimal Price { get; set; }
}
