using Microsoft.AspNetCore.Mvc;
using RecommendationApp.Application.Common.Exceptions;
using RecommendationApp.Application.Services;
using RecommendationApp.Contracts.Dtos;

namespace RecommendationApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ILogger<CommentsController> _logger;

    public CommentsController(ILogger<CommentsController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("review/{reviewId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CommentDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> GetCommentsByReviewId(Guid reviewId, [FromServices] ICommentService commentService)
    {
        try
        {
            var result = await commentService.GetCommentsByReviewIdAsync(reviewId);

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while getting comments by review id {ReviewId}", reviewId);
            return Problem(e.Message);
        }
    }
}