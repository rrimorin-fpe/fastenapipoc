global using FastEndpoints;

using fastenapipoc;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSingleton<IMyService, MyService>();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.Run();
