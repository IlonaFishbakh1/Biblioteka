using Biblioteka.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!roleManager.RoleExistsAsync(role)
            .GetAwaiter()
            .GetResult())
            roleManager.CreateAsync(new IdentityRole(role))
                .GetAwaiter()
                .GetResult();
    }

    var adminEmail = "admin@admin.com";
    var adminUser = userManager.FindByEmailAsync(adminEmail)
        .GetAwaiter()
        .GetResult();
    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        userManager.CreateAsync(adminUser, "Haslo123!")
            .GetAwaiter()
            .GetResult();
        userManager.AddToRoleAsync(adminUser, "Admin")
            .GetAwaiter()
            .GetResult();
    }

    var userEmail = "user@user.com";
    var normalUser = userManager.FindByEmailAsync(userEmail)
        .GetAwaiter()
        .GetResult();
    if (normalUser == null)
    {
        normalUser = new IdentityUser { UserName = userEmail, Email = userEmail, EmailConfirmed = true };
        userManager.CreateAsync(normalUser, "User123!")
            .GetAwaiter()
            .GetResult();
        userManager.AddToRoleAsync(normalUser, "User")
            .GetAwaiter()
            .GetResult();
    }
}

app.Run();
