using api.Models;

namespace api.Services;
public interface INewsletterServices
{
    SignUpResponse SignUp(SignUpRequest request);
}
