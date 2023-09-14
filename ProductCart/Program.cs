using ProductCart.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProduct_Service, Product_Service>();
builder.Services.AddScoped<IUser_Service, User_Service>();
builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();


// Add session support
builder.Services.AddDistributedMemoryCache(); // Use an in-memory cache for storing session data
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true; // Set HttpOnly to true for improved security
    options.Cookie.IsEssential = true; // Mark the cookie as essential for GDPR compliance
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Set the session timeout (e.g., 20 minutes)
});
// Add HttpContextAccessor to the service container
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Add the session configuration
app.UseSession();


app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});
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
    pattern: "{controller=ProductUI}/{action=ProductHome}/{id?}");

app.Run();
