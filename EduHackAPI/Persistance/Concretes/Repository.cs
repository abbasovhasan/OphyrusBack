using Application.Abstraction.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Linq.Expressions;


namespace Persistance.Concretes;
public class Repository<T> : IRepository<T>, IReadRepository<T>, IWriteRepository<T> where T : BaseEntity
{
    private readonly EduHackDbContext _context;
    public DbSet<T> Table => _context.Set<T>();

    public Repository(EduHackDbContext context)
    {
        _context = context;
    }

    // CRUD işlemleri - Genel
    public async Task<T> GetByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // **Async Update** metodu ekliyoruz
    public async Task UpdateAsync(T entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }

    // **Async Delete** metodu ekliyoruz
    public async Task DeleteAsync(T entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    // İsteğe bağlı olarak filtreleme metotları eklenebilir.
    // Örneğin, StartTime ve EndTime aralığını sorgulamak için:
    public async Task<IEnumerable<T>> GetByTimeRangeAsync(DateTime startTime, DateTime endTime)
    {
        return await Table.Where(e => EF.Property<DateTime>(e, "StartTime") >= startTime && EF.Property<DateTime>(e, "EndTime") <= endTime).ToListAsync();
    }
}
