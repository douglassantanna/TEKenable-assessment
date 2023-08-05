using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterController : ControllerBase
{
    private readonly INewsletterServices _newsletterServices;
    private readonly ILogger<NewsletterController> _logger;

    public NewsletterController(INewsletterServices newsletterServices, ILogger<NewsletterController> logger)
    {
        _newsletterServices = newsletterServices;
        _logger = logger;
    }

    [HttpPost("sign-up")]
    public IActionResult SignUp(SignUpRequest request)
    {
        var response = _newsletterServices.SignUp(request);
        if (!response.Success)
        {
            _logger.LogError(response.Message);
            return BadRequest(response);
        }
        return Ok();
    }
}
