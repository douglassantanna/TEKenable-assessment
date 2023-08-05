using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models;

public class Contact
{
    public int Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string ReasonForSignUp { get; private set; } = string.Empty;
    public EHowHeardAboutUs HowHeardAboutUs { get; private set; }
}
