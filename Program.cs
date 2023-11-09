using Greab_Alexandra_lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Greab_Alexandra_lab2Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Greab_Alexandra_lab2Context") 
?? throw new InvalidOperationException("Connectionstring 'Greab_Alexandra_lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("Greab_Alexandra_lab2Context") 
?? throw new InvalidOperationException("Connectionstring 'Nume_Pren_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryIdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
