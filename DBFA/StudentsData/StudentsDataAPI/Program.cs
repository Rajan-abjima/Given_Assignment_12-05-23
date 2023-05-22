using Microsoft.EntityFrameworkCore;
using Serilog;
using StudentsDataAPI.DbContexts;
using StudentsDataAPI.Profiles;
using StudentsDataAPI.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddDbContext<DbContext>();

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddDbContext<StudentsDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(StudentDataProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
