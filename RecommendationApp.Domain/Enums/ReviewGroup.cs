using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecommendationApp.Domain.Enums;

public enum ReviewGroup
{
    [Description("Movies")]
    Movies = 0,
    [Description("Books")]
    Books = 1,
    [Description("Video Games")]
    Games = 2,
    [Description("Music")]
    Music = 3,
    [Description("TV Shows")]
    TVShows = 4,
    [Description("Other")]
    Other = 5
}