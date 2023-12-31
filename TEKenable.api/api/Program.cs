using api.Data;
using api.Models;
using api.Services;
using api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<INewsletterServices, NewsletterServices>();
    builder.Services.AddScoped<IValidator<SignUpRequest>, SignUpRequestValidator>();
    builder.Services.AddDbContext<NewsletterDataContext>(opt => opt.UseInMemoryDatabase("Database"));
    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("AllowAll");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
