using WrapperPoc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISmtpClient, SmtpClientWrapper>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
