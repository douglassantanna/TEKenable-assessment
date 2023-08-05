using api.Controllers;
using api.Data;
using api.Models;
using api.Services;
using api.Validators;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace tests;

public class NewsletterTests
{
    private readonly SignUpRequestValidator _validator;
    private readonly SignUpRequest _validRequest;
    private readonly SignUpRequest _invalidRequest;
    private readonly Mock<INewsletterServices> _mockNewsletterServices;
    private readonly Mock<ILogger<NewsletterServices>> _mockNewsletterServicesLogger;

    private readonly Mock<ILogger<NewsletterController>> _mockControllerLogger;
    public NewsletterTests()
    {
        _mockNewsletterServices = new();
        _mockNewsletterServicesLogger = new();
        _mockControllerLogger = new();
        _validator = new SignUpRequestValidator();
        _invalidRequest = new SignUpRequest("invalid-email",
                                            "Reason",
                                            EHowHeardAboutUs.Advert);
        _validRequest = new SignUpRequest("test@example.com",
                                           "Reason",
                                           EHowHeardAboutUs.WordOfMouth);
    }

    private DbContextOptions<NewsletterDataContext> GetInMemoryDbContextOptions()
    {
        var optionsBuilder = new DbContextOptionsBuilder<NewsletterDataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());

        return optionsBuilder.Options;
    }

    [Fact]
    public void ShouldHaveErrorWhenEmailIsInvalid()
    {
        // Act
        var result = _validator.TestValidate(_invalidRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void ShouldNotHaveErrorWhenEmailIsValid()
    {
        // Act
        var result = _validator.TestValidate(_validRequest);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void IsEmailAlreadySignedUp_EmailExists_ReturnsTrue()
    {
        //Arrange
        var context = new NewsletterDataContext(GetInMemoryDbContextOptions());

        context.Contacts.Add(new Contact("test@example.com", "Reason", EHowHeardAboutUs.Advert));
        context.SaveChanges();

        //Act
        var service = new NewsletterServices(context,
                                             Mock.Of<IValidator<SignUpRequest>>(),
                                             _mockNewsletterServicesLogger.Object);

        var result = service.IsEmailAlreadySignedUp(_validRequest);

        //Asser
        Assert.True(result);
    }

    [Fact]
    public void SigningUp_EmailDoesntExist_ReturnsFalse()
    {
        //Arrange
        var context = new NewsletterDataContext(GetInMemoryDbContextOptions());

        var service = new NewsletterServices(context,
                                             Mock.Of<IValidator<SignUpRequest>>(),
                                             _mockNewsletterServicesLogger.Object);

        //Act
        var result = service.IsEmailAlreadySignedUp(_validRequest);

        //Assert
        Assert.False(result);
    }
    [Fact]
    public void SigningUp_EmailDoesntExist_AddsContact()
    {
        //Arrange
        var mockValidator = new Mock<IValidator<SignUpRequest>>();
        mockValidator.Setup(v => v.Validate(It.IsAny<SignUpRequest>()))
            .Returns(new FluentValidation.Results.ValidationResult());

        var context = new NewsletterDataContext(GetInMemoryDbContextOptions());

        var service = new NewsletterServices(context,
                                             mockValidator.Object,
                                             _mockNewsletterServicesLogger.Object);

        // Act
        var response = service.SignUp(_validRequest);

        // Assert
        Assert.True(response.Success);
        Assert.Single(context.Contacts);
    }

    [Fact]
    public void SignUp_SuccessfulSignUp_ReturnsOk()
    {
        // Arrange
        _mockNewsletterServices.Setup(s => s.SignUp(It.IsAny<SignUpRequest>()))
            .Returns(new SignUpResponse { Success = true });

        var controller = new NewsletterController(_mockNewsletterServices.Object, _mockControllerLogger.Object);

        // Act
        var result = controller.SignUp(_validRequest);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void SignUp_UnsuccessfulSignUp_ReturnsBadRequest()
    {
        // Arrange
        _mockNewsletterServices.Setup(s => s.SignUp(It.IsAny<SignUpRequest>()))
            .Returns(new SignUpResponse { Success = false });

        var controller = new NewsletterController(_mockNewsletterServices.Object, _mockControllerLogger.Object);

        // Act
        var result = controller.SignUp(_validRequest);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}