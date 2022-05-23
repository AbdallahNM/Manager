using Manager.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configuration Service
builder.Services.AddMvc(option => option.EnableEndpointRouting = false).AddXmlSerializerFormatters();
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddDbContextPool<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ManagerDataBase")).EnableSensitiveDataLogging());
#endregion
var app = builder.Build();

#region Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseMvc();

//app.UseMvcWithDefaultRoute();

//app.UseMvc(routes =>
//{
//    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
//});

//app.MapGet("/", () => "Hello World!");

app.Run();
#endregion