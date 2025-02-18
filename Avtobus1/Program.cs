using Avtobus1.Context;
using Avtobus1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

DotNetEnv.Env.Load();

if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
{
    throw new Exception("No env variable \"CONNECTION_STRING\"");
}

builder.Services.AddDbContext<LinkContext>();

builder.Services.AddTransient<ILinkService, LinkService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
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
