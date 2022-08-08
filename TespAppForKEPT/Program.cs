using DataAccess.SQLServer;
using Domain.Logic.MappingDTO;
using Domain.Logic.Service.Implementation;
using Domain.Logic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});

builder.Services.AddScoped<IService<CompanyDTO>, CompanyService>();
builder.Services.AddScoped<IService<UserDTO>, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Operations",
        Version = "v1"
    });
});

builder.Services.AddDbContext<ITestAppKeptDbContext, TestAppKeptDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint(
 "/swagger/v1/swagger.json", "API Operations v1"));
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    ITestAppKeptDbContext testAppKeptDbContext = scope.ServiceProvider.GetRequiredService<ITestAppKeptDbContext>();

    DbInitialize.Initial(testAppKeptDbContext);
}
app.Run();
