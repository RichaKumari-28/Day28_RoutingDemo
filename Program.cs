var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Custom Routes
app.MapControllerRoute(
    name: "about",
    pattern: "about-us",
    defaults: new { controller = "Home", action = "About" });

app.MapControllerRoute(
    name: "contact",
    pattern: "contact/{department?}",
    defaults: new { controller = "Home", action = "Contact" });

app.MapControllerRoute(
    name: "products",
    pattern: "products",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "product-details",
    pattern: "products/details/{id}",
    defaults: new { controller = "Home", action = "Index" });

//  Default Route should be last
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();