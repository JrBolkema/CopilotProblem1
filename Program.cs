// This file contains source code modified by GitHub Copilot.

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    if (context.Request.Method != "POST")
    {
        context.Response.StatusCode = 405; // Method Not Allowed
    }
    else
    {
        await next();
    }
});

app.MapControllers();

app.Run();
