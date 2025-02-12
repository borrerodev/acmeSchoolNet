using Microsoft.OpenApi.Models;
using School.Api.Extensions;
using School.Application;
using School.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo 
        { 
            Title = "Acme School API", 
            Version = "v1" 
        });
    });


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Generate the migration DB SchoolDbContext
app.UseRouting();
app.ApplyMigrations();
await app.SeedSchoolCourse();
app.UseAuthorization(); // Add it here
app.MapControllers();

app.Run();
