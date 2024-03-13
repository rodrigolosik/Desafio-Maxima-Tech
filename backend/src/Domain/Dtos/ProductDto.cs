namespace Domain.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Department { get; set; }
    public Guid DepartmentId { get; set; }
    public double Price { get; set; }
}
