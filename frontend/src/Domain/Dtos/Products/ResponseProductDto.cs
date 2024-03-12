namespace Domain.Dtos.Products;

public class ResponseProductDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Guid DepartmentId { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
}
