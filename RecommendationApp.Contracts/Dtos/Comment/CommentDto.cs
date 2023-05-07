using AutoMapper;
using RecommendationApp.Contracts.Mappings;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Contracts.Dtos;

public class CommentDto : IMapFrom<Comment>
{
    public Guid ReviewId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public DateTimeOffset CreatedOnUtc { get; set; }

    public void Mapping(Profile profile)
    {
        // create map from Comment to CommentDto
        profile.CreateMap<Comment, CommentDto>()
            .ForMember(d => d.Username, opt =>
                {
                    opt.PreCondition(s => s.User != null);
                    opt.MapFrom(s => s.User.UserName);
                })
            .ForMember(d => d.Email, opt =>
                {
                    opt.PreCondition(s => s.User != null);
                    opt.MapFrom(s => s.User.Email);
                })
            .ForMember(d => d.FirstName, opt =>
                {
                    opt.PreCondition(s => s.User != null);
                    opt.MapFrom(s => s.User.FirstName);
                })
            .ForMember(d => d.LastName, opt =>
                {
                    opt.PreCondition(s => s.User != null);
                    opt.MapFrom(s => s.User.LastName);
                });
    }
}