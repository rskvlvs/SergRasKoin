using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SergRasKoin.Extensions;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Features.Managers;
using SergRasKoin.Storage.DataBase;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o =>
	{
		o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
	}));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddWebServices();

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
