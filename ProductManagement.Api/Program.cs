using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductManagement.Api.DBOperations;
using ProductManagement.Api.Middlewares;
using ProductManagement.Api.Service;
using ProductManagement.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// ✅ 1️⃣ Service Bağımlılıklarını (Dependency Injection) Ekleme
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ✅ 2️⃣ Fluent Validation Kullanımı
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

// ✅ 3️⃣ InMemory Database Bağlantısını Tanımla
builder.Services.AddDbContext<ProductManagementDbContext>(options =>
    options.UseInMemoryDatabase("ProductManagementDB"));

// ✅ 4️⃣ Swagger Desteği Ekleme
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product Management API",
        Version = "v1",
        Description = "A simple product management API."
    });
});

// ✅ 5️⃣ Service Katmanını Tanımla
builder.Services.AddScoped<IProductService, FakeProductService>();

var app = builder.Build();

// ✅ 6️⃣ InMemory Database İçin Örnek Veri Üret (Data Seed)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// ✅ 7️⃣ Middleware Yapılandırması
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API v1");
        c.RoutePrefix = string.Empty; // Swagger'ı ana sayfada aç
    });
}

// ✅ 8️⃣ Global Exception Middleware'i Ekle (Hata Yönetimi)
app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();
app.UseAuthorization();

// ✅ 9️⃣ Controller Endpointlerini Etkinleştir
app.MapControllers();

app.Run();