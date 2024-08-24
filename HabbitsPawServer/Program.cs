using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы, включая контроллеры и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Это необходимо для Swagger
builder.Services.AddSwaggerGen();           // Это необходимо для генерации Swagger

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();
// Включаем CORS
app.UseCors("AllowReactApp");

// Включаем Swagger и SwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Включаем генерацию Swagger JSON документа
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Открываем Swagger по умолчанию на корневом URL
    });
}

// Добавляем маршрутизацию контроллеров
app.MapControllers();

app.Run();
