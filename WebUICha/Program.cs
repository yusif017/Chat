using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebUICha.Data;
using WebUICha.DependencyResolver;
using WebUICha.Hubs;
using WebUICha.Model;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
.AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

builder.Services.Create();

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
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Register}/{id?}");
app.MapHub<MessageHubs>("/message");

app.Run();
