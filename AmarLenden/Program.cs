using AmarLenden.Interfaces;
using AmarLenden.Repositories;
using AmarLendenAPI.Data;
using AmarLendenAPI.Interfaces;
using AmarLendenAPI.Mappings;
using AmarLendenAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency injection
builder.Services.AddScoped(typeof(IBasicRepository<>), typeof(BasicRepository<>));
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add controllers
builder.Services.AddControllers();

// Swagger (for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - You should ideally define a named policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Use named CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
