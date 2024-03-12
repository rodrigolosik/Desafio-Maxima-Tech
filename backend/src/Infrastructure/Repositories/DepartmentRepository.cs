using Dapper;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Infrastructure.Repositories;

public class DepartmentRepository : BaseRepository, IDepartmentRepository
{
    private readonly ILogger<DepartmentRepository> _logger;
    private readonly IDbConnection _dbConnection;

    public DepartmentRepository(ILogger<DepartmentRepository> logger, IDbConnection dbConnection) : base(logger, dbConnection)
    {
        _logger = logger;
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        try
        {
            TryOpenConnection();
            return await _dbConnection.QueryAsync<Department>("SELECT * FROM Departments");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Enumerable.Empty<Department>();
        }
        finally
        {
            CloseConnection();
        }
    }
}
