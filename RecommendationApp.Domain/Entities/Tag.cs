using RecommendationApp.Domain.Common;

namespace RecommendationApp.Domain.Entities;

public class Tag : BaseIEntity<Guid>
{
    public string Name { get; set; }
    
    public List<ReviewTag> ReviewTags { get; set; }
}