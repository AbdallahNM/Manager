using Manager.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configuration Service
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
builder.Services.AddDbContextPool<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ManagerDataBase")));
#endregion
var app = builder.Build();

#region Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

//app.UseMvc();

//app.UseMvcWithDefaultRoute();

app.UseMvc(routes =>
{
    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
#endregion