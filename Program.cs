using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RestaurantsFlexDevAcademy.Data;
using RestaurantsFlexDevAcademy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RestaurantContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantsContext")),
ServiceLifetime.Singleton);

builder.Services.AddSingleton<IRestaurantService, RestaurantService>();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    var context = services.GetRequiredService<RestaurantContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
