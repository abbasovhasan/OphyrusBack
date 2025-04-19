using Application.Abstraction.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Linq.Expressions;

namespace Persistance.Concretes;

public class CourseRepository : IRepository<Course>
{
    private readonly EduHackDbContext _context;
    public DbSet<Course> Table => _context.Set<Course>();

    public CourseRepository(EduHackDbContext context)
    {
        _context = context;
    }

    // Kursu ID'ye göre getirme
    public async Task<Course> GetByIdAsync(Guid id)
    {
        return await Table.Include(c => c.Topics).FirstOrDefaultAsync(c => c.Id == id);
    }

    // Tüm kursları getirme
    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await Table.Include(c => c.Topics).ToListAsync();
    }

    // Kursu bir şart ile arama
    public async Task<IEnumerable<Course>> FindAsync(Expression<Func<Course, bool>> predicate)
    {
        return await Table.Where(predicate).Include(c => c.Topics).ToListAsync();
    }

    // Kurs ekleme
    public async Task AddAsync(Course entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // Kurs güncelleme
    public async Task UpdateAsync(Course entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }

    // Kurs silme
    public async Task DeleteAsync(Course entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
