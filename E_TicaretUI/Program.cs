using E_TicaretBLL.Abstract;
using E_TicaretBLL.Concreate;
using E_TicaretDAL.Abstract;
using E_TicaretDAL.Concreate;
using E_TicaretDAL.Data;
using E_TicaretEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SellerService, SellerManager>();
builder.Services.AddScoped<ISeller_DAL, Seller_DAL>();
builder.Services.AddScoped<ProductService, ProductManager>();
builder.Services.AddScoped<IProduct_DAL, Product_DAL>();
builder.Services.AddScoped<ÝmageService,ÝmageManager>();
builder.Services.AddScoped<IÝmage_DAL, Ýmage_DAL>();
builder.Services.AddScoped<QuestýonService, QuestýonManager>();
builder.Services.AddScoped<IQuestýon_DAL, Questýon_DAL>();
builder.Services.AddScoped<CommentService, CommentManager>();
builder.Services.AddScoped<IComment_DAL, Comment_DAL>();
builder.Services.AddScoped<UIBasketService, UIBasketManager>();
builder.Services.AddScoped<IUIBasket_DAL, UIBasket_DAL>();
builder.Services.AddScoped<UIBasket_2Service, UIBasket_2Manager>();
builder.Services.AddScoped<IUIBasket_2_DAL, UIBasket_2_DAL>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddIdentity<Users, AppRole>().AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();


// IdentityOptions, ASP.NET Core Identity ayarlarýný yapýlandýrýr.
builder.Services.Configure<IdentityOptions>(options =>
{
    // Kullanýcýnýn parolasýnýn en az bir rakam içermesi gerektiðini belirtir.
    options.Password.RequireDigit = true;

    // Kullanýcýnýn parolasýnýn en az bir küçük harf içermesi gerektiðini belirtir.
    options.Password.RequireLowercase = true;

    // Kullanýcýnýn parolasýnýn en az bir büyük harf içermesi gerektiðini belirtir.
    options.Password.RequireUppercase = false;

    // Kullanýcýnýn parolasýnýn en az 6 karakter uzunluðunda olmasý gerektiðini belirtir.
    options.Password.RequiredLength = 2;

    // Kullanýcýnýn parolasýnýn en az bir özel karakter içermesi gerektiðini belirtir.
    options.Password.RequireNonAlphanumeric = false;

    // Kilitlenme ayarlarý
    options.Lockout.MaxFailedAccessAttempts = 10; // Kullanýcýnýn belirli sayýda baþarýsýz giriþ denemesine izin verir.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10); // Kullanýcýnýn hesabýnýn kilitlenme süresini belirtir.
    options.Lockout.AllowedForNewUsers = true; // Yeni kullanýcýlarýn kilitlenip kilitlenmeyeceðini belirtir.

    // Kullanýcý adý karakterleri için özelleþtirme seçeneði (kodda devre dýþý býrakýlmýþ).
    // options.User.AllowedUserNameCharacters = "1";

    // Telefon onayý gerektirme seçeneði
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // E-posta onayý gerektirme seçeneði
    options.SignIn.RequireConfirmedEmail = false;
});

// ApplicationCookie, oturum yönetimi için kullanýlan çerez ayarlarýný yapýlandýrýr.
builder.Services.ConfigureApplicationCookie(options =>
{
    // Giriþ sayfasýnýn yolu
    options.LoginPath = "/Account/Login";

    // Çýkýþ sayfasýnýn yolu
    options.LogoutPath = "/Account/Login";

    // Eriþim reddedildiðinde yönlendirilen sayfanýn yolu
    options.AccessDeniedPath = "/account/Login";

    // Oturum süresi (60 dakika)
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

    // Oturum süresinin otomatik uzatýlmasýný etkinleþtirir.
    options.SlidingExpiration = true;

    // Çerez ayarlarý
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true, // Taraf sunucu dýþýndaki eriþimleri engeller.
        Name = "E_TicaretUI.Security.Cookie", // Çerezin adý
        SameSite = SameSiteMode.Strict // Tarayýcý güvenliði için sýký sýnýrlar uygular.
    };
});

// ControllersWithViews, denetleyicileri ve görünümleri yapýlandýrýr.
builder.Services.AddControllersWithViews(options =>
{
    // CSRF saldýrýlarýný engellemek için otomatik olarak anti-forgery token ekler.
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Wellcome}/{id?}");

app.Run();
