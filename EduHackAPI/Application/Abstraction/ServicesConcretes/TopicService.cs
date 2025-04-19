using Application.Abstraction.Repositories;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.Abstraction.Services;
public class TopicService : ITopicService
{
    private readonly IRepository<Topic> _topicRepository;
    private readonly IMapper _mapper;

    public TopicService(IRepository<Topic> topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }

    // Tüm topicleri listele
    public async Task<IEnumerable<TopicDTO>> GetAllTopicsAsync()
    {
        var topics = await _topicRepository.GetAllAsync(); // Topicleri veritabanından al
        return _mapper.Map<IEnumerable<TopicDTO>>(topics); // Topicleri DTO'ya dönüştür
    }

    // Topic ID ile getir
    public async Task<TopicDTO> GetTopicByIdAsync(Guid id)
    {
        var topic = await _topicRepository.GetByIdAsync(id); // Veritabanından topic'i al
        return _mapper.Map<TopicDTO>(topic); // Topic'i DTO'ya dönüştür
    }

    // Yeni Topic ekle
    public async Task AddTopicAsync(CreateTopicDTO createTopicDTO)
    {
        var topic = _mapper.Map<Topic>(createTopicDTO); // DTO'dan Topic modeline dönüştür
        await _topicRepository.AddAsync(topic); // Topic'i veritabanına ekle
    }

    // Topic güncelle
    public async Task UpdateTopicAsync(Guid id, CreateTopicDTO updateTopicDTO)
    {
        var topic = _mapper.Map<Topic>(updateTopicDTO); // DTO'dan Topic modeline dönüştür
        topic.Id = id; // ID'yi güncelle
        await _topicRepository.UpdateAsync(topic); // Topic'i veritabanında güncelle
    }

    // Topic sil
    public async Task DeleteTopicAsync(Guid id)
    {
        var topic = await _topicRepository.GetByIdAsync(id); // ID'ye göre topic'i al
        if (topic != null)
        {
            await _topicRepository.DeleteAsync(topic); // Topic'i veritabanından sil
        }
    }

    // Topicleri bir şart ile ara
    public async Task<IEnumerable<Topic>> FindAsync(Expression<Func<Topic, bool>> predicate)
    {
        return await _topicRepository.FindAsync(predicate); // Predicate'a göre topicleri ara
    }

    // Topic'i ID'ye göre al
    public async Task<Topic> GetByIdAsync(Guid id)
    {
        return await _topicRepository.GetByIdAsync(id); // Topic ID'ye göre al
    }

    // Tüm Topicleri listele
    public async Task<IEnumerable<Topic>> GetAllAsync()
    {
        return await _topicRepository.GetAllAsync(); // Tüm topicleri listele
    }

    // Topicleri DTO formatında getir
    public async Task<IEnumerable<TopicDTO>> GetTopicsAsync()
    {
        var topics = await _topicRepository.GetAllAsync(); // Veritabanından topicleri al
        return _mapper.Map<IEnumerable<TopicDTO>>(topics); // DTO'ya dönüştür
    }

    // Topic ekleme (IService<T> üzerinden gelen metot)
    public async Task AddAsync(Topic entity)
    {
        await _topicRepository.AddAsync(entity); // Topic'i veritabanına ekle
    }

    // Topic güncelleme (IService<T> üzerinden gelen metot)
    public async Task UpdateAsync(Topic entity)
    {
        await _topicRepository.UpdateAsync(entity); // Topic'i veritabanında güncelle
    }

    // Topic silme (IService<T> üzerinden gelen metot)
    public async Task DeleteAsync(Topic entity)
    {
        await _topicRepository.DeleteAsync(entity); // Topic'i veritabanından sil
    }
}