using Application.Abstraction.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Linq.Expressions;

namespace Persistance.Concretes;

public class TopicRepository : IRepository<Topic>, IReadRepository<Topic>, IWriteRepository<Topic>
{
    private readonly EduHackDbContext _context;
    public DbSet<Topic> Table => _context.Set<Topic>();

    public TopicRepository(EduHackDbContext context)
    {
        _context = context;
    }

    // CRUD işlemleri - Genel
    public async Task<Topic> GetByIdAsync(Guid id)
    {
        return await Table.Include(t => t.Course).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Topic>> GetAllAsync()
    {
        return await Table.Include(t => t.Course).ToListAsync();
    }

    public async Task<IEnumerable<Topic>> FindAsync(Expression<Func<Topic, bool>> predicate)
    {
        return await Table.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Topic entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Topic entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Topic entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
    }
}