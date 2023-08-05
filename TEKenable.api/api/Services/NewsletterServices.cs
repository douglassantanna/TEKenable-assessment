using api.Data;
using api.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace api.Services;
public class NewsletterServices : INewsletterServices
{
    private readonly NewsletterDataContext _context;
    private readonly IValidator<SignUpRequest> _validator;

    public NewsletterServices(NewsletterDataContext context,
                              IValidator<SignUpRequest> validator)
    {
        _context = context;
        _validator = validator;
    }

    public IEnumerable<Contact> GetContacts()
    {
        return _context.Contacts.AsNoTracking();
    }

    public SignUpResponse SignUp(SignUpRequest request)
    {
        var validationResult = _validator.Validate(request);
        var response = new SignUpResponse();
        if (!validationResult.IsValid)
        {
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            response.Success = false;
            return response;
        }

        if (IsEmailAlreadySignedUp(request))
        {
            response.Errors.Add("You have already signed up!");
            response.Success = false;
            return response;
        }

        AddContact(new Contact(request.Email,
                              request.ReasonForSignUp,
                              request.HowHeardAboutUs));

        response.Message = "Thanks for signing up!";
        _context.SaveChanges();
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
