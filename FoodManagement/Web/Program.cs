using Microsoft.EntityFrameworkCore;
using Web.Areas.Filters;
using Web.Models.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<FoodContext>(options =>
        options.UseSqlServer(
        builder.Configuration.GetConnectionString("FoodDb")
         ));

//Luu phien dang nhap
builder.Services.AddSession(
    cfg =>
    {
        cfg.Cookie.IsEssential = true;
        cfg.IdleTimeout = new TimeSpan(0, 15, 0);
    });

//Kiem tra nguoi dung co dang nhap de vo trang Admin khong
builder.Services.AddMvc(
    cfg =>
    {
        cfg.Filters.Add(new CostomActionFilter());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}" 
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
