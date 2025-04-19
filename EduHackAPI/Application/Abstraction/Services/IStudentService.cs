using Application.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface IStudentService 
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(Guid id);
        Task<Guid> AddStudentAsync(CreateStudentDTO createStudentDTO);
        Task UpdateStudentAsync(Guid id, CreateStudentDTO updateStudentDTO);
        Task DeleteStudentAsync(Guid id);
    }
}
