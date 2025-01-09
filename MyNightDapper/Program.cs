using MyNightDapper.Context;
using MyNightDapper.Repositories;
using MyNightDapper.Repositories.CategoryRepositories;
using MyNightDapper.Repositories.ProductRepositories;
using MyNightDapper.Repositories.SpofityRepositories;

var builder = WebApplication.CreateBuilder(args);

//  1. Servisleri ekleme
builder.Services.AddControllersWithViews(); // MVC deste�i
builder.Services.AddHttpClient();

//  2. Ba��ml�l�klar� ekleme (Dependency Injection)
builder.Services.AddScoped<DapperContext>(); // DapperContext DI
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // CategoryRepository DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ISpofityRepository, SpofityRepository>();

builder.Services.Configure<MyNightDapper.Models.RapidApiSettings>(
    builder.Configuration.GetSection("RapidApi")
);


//  3. Di�er servisler (�rn: Session, Cors vb. kullan�lacaksa eklenebilir)
// builder.Services.AddSession(); // �rnek bir ekleme

var app = builder.Build();

//  4. Hata Y�netimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS (HTTP Strict Transport Security) etkinle�tirildi
}

//  5. Middleware'ler
app.UseHttpsRedirection(); // HTTPS y�nlendirme
app.UseStaticFiles();       // Statik dosyalar (css, js, img vb.)

app.UseRouting();           // Rotalama etkinle�tirildi

app.UseAuthorization();     // Yetkilendirme middleware

//  6. �zel Rotalama (Varsay�lan route tan�m�)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//  7. Uygulamay� �al��t�r
app.Run();
