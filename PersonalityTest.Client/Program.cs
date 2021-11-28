using PersonalityTest;
using PersonalityTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDBServices();
builder.Services.AddBusinessServices();

builder.Services.AddControllers();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}");

app.MapFallbackToFile("index.html"); ;

app.Run();
