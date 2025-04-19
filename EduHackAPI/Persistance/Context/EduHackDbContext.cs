using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context;

public class EduHackDbContext : DbContext
{
    public EduHackDbContext(DbContextOptions<EduHackDbContext> options) : base(options)
    {
    }

    // Tabloları DbSet olarak tanımlıyoruz
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Topic> Topics { get; set; }

    // Entity konfigürasyonlarını burada yapıyoruz
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Örneğin: Entity konfigürasyonu (isteğe bağlı)
        modelBuilder.Entity<Teacher>().HasKey(t => t.Id);
        modelBuilder.Entity<Student>().HasKey(s => s.Id);
        modelBuilder.Entity<Course>().HasKey(c => c.Id);
        modelBuilder.Entity<Topic>().HasKey(t => t.Id);
    }
}
