using NLog;
using Skeleton.Abstraction;
using Skeleton.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Logger configuration.
// Log messages are saved on \bin\Debug\Net#\logs.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
    "/nlog.config"));

// Add services to the container.
builder.Services.ConfigureLoggerManager();
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Skeleton.Presentation.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global error handling setup.
var logger = app.Services.GetService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

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