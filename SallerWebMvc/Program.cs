using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SallerWebMvc.Data;
var builder = WebApplication.CreateBuilder(args);

//configurando string de conexao
var connectionString = builder.Configuration.GetConnectionString("SallerWebMvcContextConection")
    ?? throw new InvalidOperationException("Connection string 'SallerWebMvcContextConection' not found.");

// Configurando o DbContext, odbcontext deve ter o mesmo nome usado no arquivo context dentro da pasta Data
builder.Services.AddDbContext<SallerWebMvcContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

//chamando o SeedingService para popular o banco de dados
using(var scope = app.Services.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetService<SeedingService>();
    seedingService.Seed();
}

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
