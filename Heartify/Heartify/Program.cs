var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

await app.RunAsync();


/*
 Scaffold :
 Identity Account Manage
 Identity Account Manage Email
 Identity Account Manage ChangePassword
 Identity Account Manage TwoFactorAuth
 Identity Account Manage PersonalData
 Identity Account Manage DeletePersonalData
 Identity Account RegisterConfirmation
 Identity Account ConfirmEmail
 */

// https://stackoverflow.com/questions/25400555/save-and-retrieve-image-binary-from-sql-server-using-entity-framework-6   IMAGE TO BYTE[]