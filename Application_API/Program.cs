using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Newtonsoft;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen().AddSwaggerGenNewtonsoftSupport();
builder.Services.AddDbContext<EStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EStoreDatabase"));
});
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
