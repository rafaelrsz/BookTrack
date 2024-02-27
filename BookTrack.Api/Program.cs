using BookTrack.Api.Endpoints;
using BookTrack.Api.Extentions;
using BookTrack.Infra.Data;
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

var app = builder.Build();

if (app.Environment.IsDevelopment()) { 
  app.UseSwagger();
  app.UseSwaggerUI();
  app.ApplyMigrations();
}

app.MapAuthorEndpoints();

app.UseHttpsRedirection();

app.Run();
