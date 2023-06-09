﻿namespace RecommendationApp.Domain.Common;

public interface IAuditableEntity
{
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string IPAddress { get; set; }
}