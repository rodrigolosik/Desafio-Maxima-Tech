﻿namespace Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Guid DepartmentId { get; set; }
    public string Department { get; set; }
    public double Price { get; set; }
    public bool Status { get; set; }
}
