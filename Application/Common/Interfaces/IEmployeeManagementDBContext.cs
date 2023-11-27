using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage; 

namespace Application.Common.Interfaces
{
    public interface IEmployeeManagementDBContext
    {
        DbSet<Domain.Entities.Employee> Employees { get; set; }
        DbSet<Domain.Entities.Department> Departments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DatabaseFacade Database { get; }
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
