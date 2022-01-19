using OnlineShop.Application;
using OnlineShop.Infrastructure;
using OnlineShop.Web.Filters;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Host.ConfigureServices(services =>
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddControllers(configuration =>
    {
        configuration.Filters.Add<ValidationExceptionFilter>();
    });

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
