using MyNightDapper.Context;
using MyNightDapper.Repositories;
using MyNightDapper.Repositories.CategoryRepositories;
using MyNightDapper.Repositories.ProductRepositories;
using MyNightDapper.Repositories.SpofityRepositories;

var builder = WebApplication.CreateBuilder(args);

//  1. Servisleri ekleme
builder.Services.AddControllersWithViews(); // MVC desteði
builder.Services.AddHttpClient();

//  2. Baðýmlýlýklarý ekleme (Dependency Injection)
builder.Services.AddScoped<DapperContext>(); // DapperContext DI
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // CategoryRepository DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ISpofityRepository, SpofityRepository>();

builder.Services.Configure<MyNightDapper.Models.RapidApiSettings>(
    builder.Configuration.GetSection("RapidApi")
);


//  3. Diðer servisler (Örn: Session, Cors vb. kullanýlacaksa eklenebilir)
// builder.Services.AddSession(); // Örnek bir ekleme

var app = builder.Build();

//  4. Hata Yönetimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS (HTTP Strict Transport Security) etkinleþtirildi
}

//  5. Middleware'ler
app.UseHttpsRedirection(); // HTTPS yönlendirme
app.UseStaticFiles();       // Statik dosyalar (css, js, img vb.)

app.UseRouting();           // Rotalama etkinleþtirildi

app.UseAuthorization();     // Yetkilendirme middleware

//  6. Özel Rotalama (Varsayýlan route tanýmý)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//  7. Uygulamayý çalýþtýr
app.Run();
