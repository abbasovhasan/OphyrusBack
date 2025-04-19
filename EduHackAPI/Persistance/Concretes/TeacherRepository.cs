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

public class TeacherRepository : IRepository<Teacher>
{
    private readonly EduHackDbContext _context;
    public DbSet<Teacher> Table => _context.Set<Teacher>();

    public TeacherRepository(EduHackDbContext context)
    {
        _context = context;
    }

    // Öğretmenleri getirme
    public async Task<Teacher> GetByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    // Tüm öğretmenleri getirme
    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    // Öğretmeni bir şart ile arama
    public async Task<IEnumerable<Teacher>> FindAsync(Expression<Func<Teacher, bool>> predicate)
    {
        return await Table.Where(predicate).ToListAsync();
    }

    // Öğretmen ekleme
    public async Task AddAsync(Teacher entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // Öğretmen güncelleme
    public async Task UpdateAsync(Teacher entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }

    // Öğretmen silme
    public async Task DeleteAsync(Teacher entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
