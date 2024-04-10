using Microsoft.EntityFrameworkCore;
using SignalR.API.Hubs;
using SignalR.Business;
using SignalR.DataAccess;
using SignalR.DataAccess.Concrete.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<SignalRDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnectionString")));

builder.Services
    .AddDataAccessServices()
    .AddBusinessServices();

builder.Services.AddCors(options => 
    options.AddPolicy("CorsPolicy", policyBuilder =>
{
    policyBuilder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(_ =>true)
        .AllowCredentials();
}));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();