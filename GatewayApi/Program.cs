using WatchDog;
using WatchDog.src.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logBuilder => 
    logBuilder.AddSimpleConsole(opt => {
        opt.SingleLine = true;
        opt.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
    }));

builder.Services.AddWatchDogServices(opt => 
{ 
    opt.IsAutoClear = true;
    opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Monthly;
});

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


var app = builder.Build();

// http://localhost:5000/watchdog
app.UseWatchDog(opt => 
{ 
    opt.WatchPageUsername = "admin"; 
    opt.WatchPagePassword = "0000"; 
});

app.MapReverseProxy();
app.Run();