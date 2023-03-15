
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()));
builder.Services.AddApiVersioning(setup =>
                            {
                                setup.DefaultApiVersion = new ApiVersion(1, 0);
                                setup.AssumeDefaultVersionWhenUnspecified = true;
                                setup.ReportApiVersions = true;
                                setup.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                                  new HeaderApiVersionReader("x-api-version"),
                                                                                  new MediaTypeApiVersionReader("x-api-version"));
                            });

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
