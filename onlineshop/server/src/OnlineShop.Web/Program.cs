using OnlineShop.Application;
using OnlineShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Host.ConfigureServices(services =>
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddApplication();
    services.AddInfrastructure(builder.Configuration);
});

// Application
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
