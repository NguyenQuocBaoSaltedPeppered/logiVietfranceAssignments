using System.Reflection;
using PMApp.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    // Enable XML comment on swaggerUI
    // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
    // $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

    // Enable using Swashbuckle.AspNetCore.Annotations
    options.EnableAnnotations();
});
builder.Services.AddScoped<IProjectService, ProjectService>();

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
