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
builder.Services.AddScoped<�mageService,�mageManager>();
builder.Services.AddScoped<I�mage_DAL, �mage_DAL>();
builder.Services.AddScoped<Quest�onService, Quest�onManager>();
builder.Services.AddScoped<IQuest�on_DAL, Quest�on_DAL>();
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


// IdentityOptions, ASP.NET Core Identity ayarlar�n� yap�land�r�r.
builder.Services.Configure<IdentityOptions>(options =>
{
    // Kullan�c�n�n parolas�n�n en az bir rakam i�ermesi gerekti�ini belirtir.
    options.Password.RequireDigit = true;

    // Kullan�c�n�n parolas�n�n en az bir k���k harf i�ermesi gerekti�ini belirtir.
    options.Password.RequireLowercase = true;

    // Kullan�c�n�n parolas�n�n en az bir b�y�k harf i�ermesi gerekti�ini belirtir.
    options.Password.RequireUppercase = false;

    // Kullan�c�n�n parolas�n�n en az 6 karakter uzunlu�unda olmas� gerekti�ini belirtir.
    options.Password.RequiredLength = 2;

    // Kullan�c�n�n parolas�n�n en az bir �zel karakter i�ermesi gerekti�ini belirtir.
    options.Password.RequireNonAlphanumeric = false;

    // Kilitlenme ayarlar�
    options.Lockout.MaxFailedAccessAttempts = 10; // Kullan�c�n�n belirli say�da ba�ar�s�z giri� denemesine izin verir.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10); // Kullan�c�n�n hesab�n�n kilitlenme s�resini belirtir.
    options.Lockout.AllowedForNewUsers = true; // Yeni kullan�c�lar�n kilitlenip kilitlenmeyece�ini belirtir.

    // Kullan�c� ad� karakterleri i�in �zelle�tirme se�ene�i (kodda devre d��� b�rak�lm��).
    // options.User.AllowedUserNameCharacters = "1";

    // Telefon onay� gerektirme se�ene�i
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // E-posta onay� gerektirme se�ene�i
    options.SignIn.RequireConfirmedEmail = false;
});

// ApplicationCookie, oturum y�netimi i�in kullan�lan �erez ayarlar�n� yap�land�r�r.
builder.Services.ConfigureApplicationCookie(options =>
{
    // Giri� sayfas�n�n yolu
    options.LoginPath = "/Account/Login";

    // ��k�� sayfas�n�n yolu
    options.LogoutPath = "/Account/Login";

    // Eri�im reddedildi�inde y�nlendirilen sayfan�n yolu
    options.AccessDeniedPath = "/account/Login";

    // Oturum s�resi (60 dakika)
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

    // Oturum s�resinin otomatik uzat�lmas�n� etkinle�tirir.
    options.SlidingExpiration = true;

    // �erez ayarlar�
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true, // Taraf sunucu d���ndaki eri�imleri engeller.
        Name = "E_TicaretUI.Security.Cookie", // �erezin ad�
        SameSite = SameSiteMode.Strict // Taray�c� g�venli�i i�in s�k� s�n�rlar uygular.
    };
});

// ControllersWithViews, denetleyicileri ve g�r�n�mleri yap�land�r�r.
builder.Services.AddControllersWithViews(options =>
{
    // CSRF sald�r�lar�n� engellemek i�in otomatik olarak anti-forgery token ekler.
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
