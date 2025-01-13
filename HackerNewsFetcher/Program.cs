
using HackerNewsFetcher.DataService;
using HackerNewsFetcher.Models;
using Microsoft.AspNetCore.RateLimiting;
using System.Configuration;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHackerNewsDataService, HackerNewsDataService>();// Adding DataService

builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
 
builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit =  builder.Configuration.GetSection("Settings").GetValue<int>("PermitLimit");
        options.Window = TimeSpan.FromSeconds(builder.Configuration.GetSection("Settings").GetValue<int>("Window"));
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = builder.Configuration.GetSection("Settings").GetValue<int>("QueueLimit");
    }));


var app = builder.Build();
app.UseRateLimiter();
 
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
 
 

app.Run();
