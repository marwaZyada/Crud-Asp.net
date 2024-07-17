using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using table.context;
using table.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = false,
    CloseButton = true,
    PreventDuplicates = true,
    PositionClass = ToastPositions.TopCenter
});
var app = builder.Build();

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
app.MapRazorPages();

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Product}/{action=Index}/{id?}");



app.MapControllerRoute(
          name: "default",
          pattern: "{area=Admin}/{controller=Category}/{action=Index}/{id?}"
        );



app.Run();
