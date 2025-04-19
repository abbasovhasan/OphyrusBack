using Application.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services;
public interface ITeacherService : IService<Teacher> // IService<Teacher> arayüzünü implement ediyoruz
{
    Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync();
    Task<TeacherDTO> GetTeacherByIdAsync(Guid id);
    Task AddTeacherAsync(CreateTeacherDTO createTeacherDTO);
    Task UpdateTeacherAsync(Guid id, CreateTeacherDTO updateTeacherDTO);
    Task DeleteTeacherAsync(Guid id);
}