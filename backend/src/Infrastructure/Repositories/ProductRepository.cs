using Dapper;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    private readonly ILogger<ProductRepository> _logger;
    private readonly IDbConnection _dbConnection;

    public ProductRepository(ILogger<ProductRepository> logger, IDbConnection dbConnection) : base(logger, dbConnection)
    {
        _logger = logger;
        _dbConnection = dbConnection;
    }

    public async Task CreateAsync(Product product)
    {
        try
        {
            await _dbConnection.ExecuteAsync(@"
                INSERT INTO Products 
                    (Id, Code, Description, DepartmentId, Price) 
                VALUES 
                    (@id, @code, @description, @departmentId, @price)",
                    new
                    {
                        id = Guid.NewGuid(),
                        code = product.Code,
                        description = product.Description,
                        departmentId = product.DepartmentId,
                        price = product.Price,
                    });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: {ex.Message}");
        }
        finally
        {
            CloseConnection();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            await _dbConnection.ExecuteAsync("UPDATE Products SET Status = 0 WHERE Id = @id", new { id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        try
        {
            TryOpenConnection();
            return await _dbConnection.QueryAsync<Product>(@"
                SELECT 
                    p.Id, 
                    p.Code, 
                    p.Description, 
                    p.DepartmentId, 
                    p.Price, 
                    p.Status,
                    d.Description AS Department
                FROM 
                    Products p
                    LEFT JOIN Departments d ON p.DepartmentId = d.Id
                WHERE 
                    Status = 1");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error: " + ex.Message);

            return Enumerable.Empty<Product>();
        }
        finally
        {
            CloseConnection();
        }
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        try
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @id", new { id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task UpdateAsync(Guid id, Product product)
    {
        try
        {
            await _dbConnection.ExecuteAsync(@"
                UPDATE 
                    Products 
                SET 
                    Code = @code, 
                    Description = @description, 
                    DepartmentId = @departmentId,
                    Price = @price                     
                WHERE 
                    Id = @id", 
                    new { 
                        code = product.Code,
                        description = product.Description, 
                        departmentId = product.DepartmentId, 
                        price = product.Price, 
                        id 
                    });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}
