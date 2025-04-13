using Heartbeat.Application;
using Heartbeat.Database.Read;
using Heartbeat.Database.Read.Connection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddReadLayer(builder.Configuration);

builder.Services.AddRequestHandlers();

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.WithOrigins(builder.Configuration["Cors:AllowedOrigins"]!.Split(","))
            .WithMethods(builder.Configuration["Cors:AllowedMethods"]!.Split(","))
            .WithHeaders(builder.Configuration["Cors:AllowedHeaders"]!.Split(","));
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseEndpoints();

app.UseCors();

app.Run();