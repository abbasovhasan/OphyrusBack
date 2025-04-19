using Application.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface ITopicService : IService<Topic>
    {
        Task<IEnumerable<TopicDTO>> GetAllTopicsAsync();
        Task<TopicDTO> GetTopicByIdAsync(Guid id);
        Task AddTopicAsync(CreateTopicDTO createTopicDTO);
        Task UpdateTopicAsync(Guid id, CreateTopicDTO updateTopicDTO);
        Task DeleteTopicAsync(Guid id);
    }
}
