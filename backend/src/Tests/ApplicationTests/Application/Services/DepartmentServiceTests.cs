using Application.Services;
using AutoFixture;
using Domain.Models;
using FluentAssertions;
using Infrastructure.Repositories;
using NSubstitute;

namespace UnityTests.Application.Services;

public class DepartmentServiceTests
{
    private readonly IDepartmentRepository _departmentRepositoryMock;

    public DepartmentServiceTests()
    {
        _departmentRepositoryMock = Substitute.For<IDepartmentRepository>();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturn_ListOfProducts()
    {
        // Arrange
        var autoFixture = new Fixture();

        var departments = autoFixture.Build<Department>().CreateMany(5);

        var departmentService = new DepartmentService(_departmentRepositoryMock);

        _departmentRepositoryMock.GetAllAsync().Returns(departments);

        // Act
        var result = await departmentService.GetAllAsync();

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(5);
    }

}
