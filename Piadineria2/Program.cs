using Microsoft.EntityFrameworkCore;
using Piadineria2.DbContexts;
using Piadineria2.Model;
using Piadineria2.Profiles;
using Piadineria2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ProductInfoContext>(cfg =>
{
    var connectionString = "server=localhost;port=3307;user=root;password=test123;database=piadineria";

    ServerVersion sv = ServerVersion.AutoDetect(connectionString);
    var serverVersion = new MySqlServerVersion(sv.Version);

    cfg.UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();

});




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductDbRepository, ProductDbRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(PiadinaProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
