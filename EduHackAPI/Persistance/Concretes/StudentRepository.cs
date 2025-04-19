using Application.Abstraction.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Concretes;

public class StudentRepository : IRepository<Student>
{
    private readonly EduHackDbContext _context;
    public DbSet<Student> Table => _context.Set<Student>();

    public StudentRepository(EduHackDbContext context)
    {
        _context = context;
    }

    // Öğrenciyi ID'ye göre getirme
    public async Task<Student> GetByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    // Tüm öğrencileri getirme
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    // Öğrenciyi bir şart ile arama
    public async Task<IEnumerable<Student>> FindAsync(Expression<Func<Student, bool>> predicate)
    {
        return await Table.Where(predicate).ToListAsync();
    }

    // Öğrenci ekleme
    public async Task AddAsync(Student entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // Öğrenci güncelleme
    public async Task UpdateAsync(Student entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }

    // Öğrenci silme
    public async Task DeleteAsync(Student entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
