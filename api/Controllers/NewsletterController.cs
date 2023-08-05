using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsletterController : ControllerBase
{
    private readonly ILogger<NewsletterController> _logger;

    public NewsletterController(ILogger<NewsletterController> logger)
    {
        _logger = logger;
    }
}
