using api.Data;
using api.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace api.Services;
public class NewsletterServices : INewsletterServices
{
    private readonly NewsletterDataContext _context;
    private readonly IValidator<SignUpRequest> _validator;
    private readonly ILogger<NewsletterServices> _logger;

    public NewsletterServices(NewsletterDataContext context,
                              IValidator<SignUpRequest> validator,
                              ILogger<NewsletterServices> logger)
    {
        _context = context;
        _validator = validator;
        _logger = logger;
    }

    public IEnumerable<Contact> GetContacts()
    {
        return _context.Contacts.AsNoTracking();
    }

    public SignUpResponse SignUp(SignUpRequest request)
    {
        _logger.LogInformation("Signing up {email}", request.Email);
        var validationResult = _validator.Validate(request);
        var response = new SignUpResponse();
        if (!validationResult.IsValid)
        {
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            response.Message = "Validation failed";
            response.Success = false;
            return response;
        }

        if (IsEmailAlreadySignedUp(request))
        {
            response.Errors.Add("You have already signed up!");
            response.Message = "Email already signed up";
            response.Success = false;
            return response;
        }

        AddContact(new Contact(request.Email,
                              request.ReasonForSignUp,
                              request.HowHeardAboutUs));
        _context.SaveChanges();

        response.Message = "Thanks for signing up!";
        _logger.LogInformation("Email {email} signed up successfully", request.Email);
        return response;
    }

    public bool IsEmailAlreadySignedUp(SignUpRequest request)
    {
        return _context.Contacts.Any(x => x.Email == request.Email);
    }

    private void AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
    }
}
