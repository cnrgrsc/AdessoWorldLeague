using AdessoWorldLeague.Infrastructure.SeedData;
using AdessoWorldLeague.Application.DependencyInjection;
using AdessoWorldLeague.Infrastructure.DependencyInjection;
using AdessoWorldLeague.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Application ve Infrastructure servislerini ekliyoruz
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<DataSeeder>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// DataSeeder ile verileri yüklüyoruz
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var dataSeeder = services.GetRequiredService<DataSeeder>();
//    await dataSeeder.SeedAsync();
//}

// DataSeeder ile verileri yüklüyoruz
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();

    // Migration iþlemlerini uygula
    context.Database.Migrate();

    // Veritabanýna dummy verileri yükle
    var dataSeeder = services.GetRequiredService<DataSeeder>();
    await dataSeeder.SeedAsync();
}


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
