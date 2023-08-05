namespace api.Models;
public class Contact
{
    public Contact(string email,
                   string reasonForSignUp,
                   EHowHeardAboutUs howHeardAboutUs)
    {
        Email = email;
        ReasonForSignUp = reasonForSignUp;
        HowHeardAboutUs = howHeardAboutUs;
    }

    public int Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string ReasonForSignUp { get; private set; } = string.Empty;
    public EHowHeardAboutUs HowHeardAboutUs { get; private set; }
}
