using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;
using Persistance.Concretes;
using Persistance.Context;

var builder = WebApplication.CreateBuilder(args);

// Veritaban? ba?lant? dizesini al?yoruz
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();
// Swagger/OpenAPI için ayarlar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper'? ekliyoruz (MappingProfile'? kullan?yoruz)
builder.Services.AddAutoMapper(typeof(MappingProfile));

// DbContext'i DI container'?na ekliyoruz
builder.Services.AddDbContext<EduHackDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repository ve Service katmanlar?n? DI container'?na ekliyoruz
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(Repository<>));

// Service'leri DI container'?na ekliyoruz
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITopicService, TopicService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Uygulaman?n çal??mas?n? ba?lat?yoruz
app.Run();
