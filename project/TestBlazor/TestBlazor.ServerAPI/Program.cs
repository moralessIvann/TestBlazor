using Microsoft.EntityFrameworkCore;
using TestBlazor.ServerAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbtestBlazorContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sqlstr"));

});

builder.Services.AddCors(opciones => {
    opciones.AddPolicy("newPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("newPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
