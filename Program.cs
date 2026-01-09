using DaibucatAntonia_CherechesIlincaMaria.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<DaibucatAntonia_CherechesIlincaMariaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DaibucatAntonia_CherechesIlincaMariaContext") ?? throw new InvalidOperationException("Connection string 'DaibucatAntonia_CherechesIlincaMariaContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DaibucatAntonia_CherechesIlincaMariaContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});
builder.Services.AddRazorPages(options =>
{
   
    // Restricționăm accesul la paginile sensibile din folderul Users (Membri Sala)
   ;
    options.Conventions.AuthorizePage("/Users","AdminOnly");
    options.Conventions.AuthorizeFolder("/Abonamente", "AdminOnly");
    options.Conventions.AuthorizeFolder("/AbonamenteClienti", "AdminOnly");
    options.Conventions.AuthorizeFolder("/Plati", "AdminOnly");
    options.Conventions.AuthorizeFolder("/ClaseFitness", "AdminOnly");
    // Dacă vrei să permiți tuturor să vadă lista de membri:
    options.Conventions.AllowAnonymousToPage("/Users/Index");
    options.Conventions.AllowAnonymousToPage("/Abonamente/Index");
    options.Conventions.AllowAnonymousToPage("/AbonamenteClienti/Index");
    options.Conventions.AllowAnonymousToPage("/ClaseFitness/Index");
});
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
app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.MapRazorPages();

app.Run();
