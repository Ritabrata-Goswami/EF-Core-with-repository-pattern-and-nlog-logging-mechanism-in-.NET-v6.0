using NLog;
using Microsoft.EntityFrameworkCore;
using Cls_DbContext;
using EmployeeManagementSystem.Cls_Extensiton;


var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile("nlog.config");  //Get configuration log storage path from nlog.config

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var SqlConnStr = builder.Configuration.GetConnectionString("SqlConnStr");
builder.Services.AddDbContext<Cls_EmployeeDbContext>(option => option.UseSqlServer(SqlConnStr));
builder.Services.AddRepoManager();
builder.Services.AddLoggerManager();
builder.Services.AddUICors();
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactUI");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
