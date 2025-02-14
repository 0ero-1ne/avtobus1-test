using Avtobus1.Context;
using Avtobus1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

DotNetEnv.Env.Load();

if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
{
    throw new Exception("No env variable \"CONNECTION_STRING\"");
}

builder.Services.AddDbContext<LinkContext>(options => options.UseMySql(
    Environment.GetEnvironmentVariable("CONNECTION_STRING")!,
    new MySqlServerVersion(new Version(9, 2, 0))
));

builder.Services.AddTransient<ILinkService, LinkService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
