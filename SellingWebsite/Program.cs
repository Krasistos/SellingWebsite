using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Map endpoints
app.MapDefaultControllerRoute();
app.MapRazorPages();




// Create admin role and run app
await app.CreateAdminRoleAsync();
await app.RunAsync();