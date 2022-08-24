using APICollection.Repository;
using APICollection.Repository.Interfaces;
using APICollection.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string MiCors = "MiCors";

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PolicyCollectionDbContext>(
       options => options.UseSqlServer("name=ConnectionStrings:PolicyCConnection"));

builder.Services.AddScoped<IPCRepository, PCRepository>();
builder.Services.AddScoped<IPCFRepository, PCFRepository>();
builder.Services.AddScoped<IPISRepository, PISRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MiCors,
//        builder =>
//        {
//            builder.WithOrigins("*");
//        });
//});
var app = builder.Build();

app.UseCors(opt => opt
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
