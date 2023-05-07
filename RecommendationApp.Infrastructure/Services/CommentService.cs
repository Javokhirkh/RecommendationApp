using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecommendationApp.Application.Common;
using RecommendationApp.Application.Services;
using RecommendationApp.Contracts.Dtos;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> GetCommentsByReviewIdAsync(Guid reviewId)
    {
        var result = await _unitOfWork.CommentRepository
            .AllAsQueryable
            .AsNoTracking()
            .Include(x => x.User)
            .Where(x => x.ReviewId == reviewId)
            .ToListAsync();

        return _mapper.Map<List<CommentDto>>(result);
    }

    public async Task<CommentDto> CreateCommentAsync(CommentCreateDto commentCreateDto)
    {
        var comment = _mapper.Map<Comment>(commentCreateDto);

        await _unitOfWork.CommentRepository.AddAsync(comment);
        
        await _unitOfWork.CommitAsync();
        
        return _mapper.Map<CommentDto>(comment);
    }

    public Task DeleteCommentAsync(Guid commentId)
    {
        throw new NotImplementedException();
    }
}