﻿namespace RecommendationApp.Domain.Entities;

public class ReviewUserLike
{
    public Guid ReviewId { get; set; }
    public Guid UserId { get; set; }
    
    public Review Review { get; set; }
    public User User { get; set; }
}
