using $safeprojectname$.Filters;
using $safeprojectname$.Middleware;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Infrastructure.Db;
using $ext_safeprojectname$.Infrastructure.External;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructureDb(builder.Configuration);
builder.Services.AddInfrastructureExternal();

// Middleware registration
builder.Services.AddTransient<LogMiddleware>();

var app = builder.Build();

app.UseMiddleware<LogMiddleware>();

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
