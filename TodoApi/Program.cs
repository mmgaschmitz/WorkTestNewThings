using FluentValidation;
using FluentValidation.AspNetCore.Http;
using TodoApi.Model;
using TodoApi.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Filter tbv Validation toevoegen:
// package ForEvolve.FluentValidation.AspNetCore.Http
builder.AddFluentValidationEndpointFilter();

// Validator Koppelen
builder.Services.AddScoped<IValidator<PersonFluent>, PersonFluentValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<PersonFluentValidator>();  // depenency Injection

builder.Services.AddScoped<IValidator<PersonFluentMuliError>, PersonFluentMultiErrorValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<PersonFluentMultiErrorValidator>();  // depenency Injection

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

// Swager is dan Dood, waarschijnlijk omdat swager ook de endpoints probeer te bereiken/.
// Filter tbv Validation toevoegen:
// package ForEvolve.FluentValidation.AspNetCore.Http
app.MapPut("/api/Test01/updateFluentMan2", (TodoApi.Model.PersonFluentMuliError data, CancellationToken cancellationToken) =>
                    TypedResults.Ok(data)).AddEndpointFilter<FluentValidationEndpointFilter>();


app.Run();
