using Microsoft.AspNetCore.Mvc;

namespace RecommendationApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    
    [HttpGet("{reviewId}")]
    public async Task<IActionResult> GetReviewByIdAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }
}
