using FluentValidation;
using TodoApi.Model;
using TodoApi.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Validator Koppelen
// builder.Services.AddScoped<IValidator<PersonFluent>, PersonFluentValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PersonFluentValidator>();  // depenency Injection
builder.Services.AddScoped<IValidator<PersonFluentMuliError>, PersonFluentMultiErrorValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
