using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        // Yazma ile ilgili metotlar
        Task AddAsync(T entity);
        Task UpdateAsync(T entity); // Async Update metodu
        Task DeleteAsync(T entity); // Async Delete metodu
    }
}

