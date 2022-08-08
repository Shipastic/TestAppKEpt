
using Domain.Logic.MappingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> GetByNameAsync(string Name);
        Task<IEnumerable<T>> GetAllAsync();
        void CreateAsync(string Name, CancellationToken cancellationToken, string userName = "undefined");
        void UpdateAsync(string Name, string NewName, CancellationToken cancellationToken);
    }
}
