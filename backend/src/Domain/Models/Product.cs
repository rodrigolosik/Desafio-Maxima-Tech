using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public Guid DepartmentId { get; set; }
    [Required]
    public double Price { get; set; }
    public bool Status { get; set; }
}
