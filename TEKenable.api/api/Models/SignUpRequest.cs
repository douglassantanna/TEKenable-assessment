namespace api.Models;
public record SignUpRequest(string Email,
                            string ReasonForSignUp,
                            EHowHeardAboutUs HowHeardAboutUs);
