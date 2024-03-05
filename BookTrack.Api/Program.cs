using BookTrack.Api.Endpoints;
using BookTrack.Api.Extentions;
using BookTrack.Application.Middlewares;
using BookTrack.Application.PipelineBehaviors;
using BookTrack.Infra.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<BookTrackContext>();
builder.Services.AddDbContext<BookTrackContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString("database")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "BookTrack", 
    Version = "v1"
  });
});

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(BookTrack.Application.AssemblyReference.Assembly));

builder.Services.AddScoped<BookTrackContext, BookTrackContext>();

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                BookTrack.Infra.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddTransient<ValidationMappingMiddleware>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(BookTrack.Application.AssemblyReference.Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment()) { 
  app.UseSwagger();
  app.UseSwaggerUI();
  app.ApplyMigrations();
}

app.MapAuthorEndpoints();
app.UseMiddleware<ValidationMappingMiddleware>();

app.UseHttpsRedirection();

app.Run();
