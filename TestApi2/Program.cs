var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logBuilder => 
    logBuilder.AddSimpleConsole(opt => {
        opt.SingleLine = true;
        opt.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
    }));
var app = builder.Build();


app.MapGet("/test", () => "Result of get method api 2");
app.MapPost("/test", () => "Result of post method api 2");
app.MapPut("/test", () => "Result of put method api 2");

app.Logger.LogInformation("Starting the app");
app.Run();