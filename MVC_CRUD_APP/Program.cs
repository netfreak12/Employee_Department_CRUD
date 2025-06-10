using Microsoft.EntityFrameworkCore;
using MVC_CRUD_APP.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Register your DbContext
builder.Services.AddDbContext<MVC_CRUD_APP_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC_CRUD_APP_ConnectionString")));

// Register MVC services
builder.Services.AddControllersWithViews();

// Add authorization services
builder.Services.AddAuthorization();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();