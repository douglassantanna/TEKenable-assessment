using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsletterController : ControllerBase
{
    private readonly INewsletterServices _newsletterServices;

    public NewsletterController(INewsletterServices newsletterServices)
    {
        _newsletterServices = newsletterServices;
    }

    [HttpPost("sign-up")]
    public IActionResult SignUp(SignUpRequest request)
    {
        var response = _newsletterServices.SignUp(request);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok();
    }
}
