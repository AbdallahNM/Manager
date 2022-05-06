using Manager.Models;

var builder = WebApplication.CreateBuilder(args);

#region Configuration Service
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
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

//app.UseMvc(route =>
//{
//    route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
//});

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion