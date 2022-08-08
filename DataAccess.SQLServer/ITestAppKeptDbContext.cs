using DataAccess.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLServer
{
    public interface ITestAppKeptDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Company> Companies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        EntityEntry Entry(object entity);
    }
}
