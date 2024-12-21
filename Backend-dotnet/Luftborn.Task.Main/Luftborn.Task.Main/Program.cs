using Luftborn.Task.Main.Application.Decorators;
using Luftborn.Task.Main.Application.Services;
using Luftborn.Task.Main.Application.Strategies;
using Luftborn.Task.Main.Domain.Interfaces;
using Luftborn.Task.Main.Infrastructure;
using Luftborn.Task.Main.Infrastructure.Repos;
using Luftborn.Task.Main.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.Decorate(typeof(IRepository<>), typeof(LoggingRepoDecorator<>));
builder.Services.AddScoped<IDiscountStrategy, BlackFridayDiscountStrategy>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
