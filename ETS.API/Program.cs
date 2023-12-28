using ETS.API;
using ETS.Business;
using ETS.Business.Core;
using ETS.Business.Interfaces;
using ETS.Data;
using ETS.Data.Repository.Core;
using ETS.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost", "http://localhost:3000", "https://localhost:7097")
                          .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowedToAllowWildcardSubdomains();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureServices(services =>
{
    services.AddSingleton<IPersonelBusiness, PersonelBusiness>();
    services.AddSingleton<IUserService, UserBusiness>();
    services.AddSingleton<IPersonelDal, PersonelDal>();
    services.AddSingleton<IUserDal, UserDal>();
    services.AddSingleton<IMapper, AutoMap>();
});

//var mapper = new AutoMap();
new DBInitializer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var x = app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

