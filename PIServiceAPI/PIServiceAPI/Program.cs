using APICollection.Repository;
using BCWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using PIServiceAPI.Repository.Interfaces;

string MiCors = "MiCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PolicyInformationDbContext>(
       options => options.UseSqlServer("name=ConnectionStrings:PolicyISConnection"));

builder.Services.AddScoped<IPIRepository, PIRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
        builder =>
        {
            builder.WithOrigins("*");
        });
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
