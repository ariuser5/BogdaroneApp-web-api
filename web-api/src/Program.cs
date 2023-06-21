using BogdaroneApp.Domain.Models;
using BogdaroneApp.QuickData;
using BogdaroneApp.QuickData.Repositories;

const string AppName = "BogdaroneAppWebApi";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<GoogleDataConnection>(GoogleData.Connect(AppName));
builder.Services.AddScoped<IDbContext>(serviceProvider => {
    GoogleDataConnection connection = serviceProvider.GetRequiredService<GoogleDataConnection>();
    return new GoogleDataContext(connection, serviceProvider);
});

builder.Services.AddRepository<Product, ProductRepository>();
builder.Services.AddRepository<Image, ImageRepository>();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowLocalhost3000", builder => {
        builder.WithOrigins("http://localhost:3000");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowLocalhost3000");
app.MapGet("/Hello", () => "Hello, world!");
app.MapControllers();

app.Run();

return;