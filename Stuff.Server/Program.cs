using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Stuff.Server;

var builder = WebApplication.CreateBuilder(args);

// Create the cross origin request policy
var corsPolicy = "corsPolicy";

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the db context for the app
builder.Services.AddDbContext<ApplicationDbContext>(
	x =>
	{
		x.UseSqlite(builder.Configuration.GetConnectionString("Default"));
	});

// Add services for our app
builder.Services.AddApplicationServices();

// Add cors
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: corsPolicy,
		policy =>
		{
			policy.WithOrigins("https://localhost:5010",
				"http://localhost:5011")
			.WithMethods("*")
			.WithHeaders("*");
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(corsPolicy);

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}");

// Create a scope to get the db context
using(var scope = app.Services.CreateScope())
{
	//scope.ServiceProvider.GetService<ApplicationDbContext>().Database.EnsureDeleted();

	// Make sure the db exists
	var result = scope.ServiceProvider.GetService<ApplicationDbContext>()?.Database.EnsureCreated();
}

app.Run();
