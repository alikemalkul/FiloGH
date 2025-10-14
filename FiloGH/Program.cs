// Gerekli using'ler buraya eklenmeli (FiloGH.Application.Services.Abstract ve FiloGH.Infrastructure.Services)
using BlazorColorPicker;
using FiloGH.Application.Interfaces;
using FiloGH.Application.Services;
using FiloGH.Application.Services.Abstract;
using FiloGH.Application.Services.Concrete;
using FiloGH.Components;
using FiloGH.Core.Interfaces;
using FiloGH.Infrastructure.Data.Contexts; // DbContext için
using FiloGH.Infrastructure.Repositories; // UnitOfWork ve GenericRepository için
using FiloGH.Infrastructure.Services.Cache;
using FiloGH.Infrastructure.Services.Client;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddColorPicker();
builder.Services.AddMudServices();
builder.Services.AddScoped<StateService>();
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<IActionService, ActionService>();
builder.Services.AddSession();
builder.Services.AddScoped<NavScrollService>();
builder.Services.AddWMBOS();
builder.Services.AddScoped<MenuDataService>();

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust timeout as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register HttpClient service
builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents(options =>
{
    options.DetailedErrors = true;
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:yol");
});


// 1. SCOPED: Veri Eriþim Yönetimi (Unit of Work)
// Her HTTP isteði/Blazor devresi için ayrý bir UoW/DbContext örneði oluþturulur.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// !!! KRÝTÝK DEÐÝÞÝKLÝK: TId desteðini eklemek için Repository kaydýný güncelliyoruz.
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
// 2. SINGLETON: Önbellek Servisi (Uygulama yaþamý boyunca tek)
// Tüm uygulama katmanlarý, tek bir Cache Service örneðini kullanýr.
builder.Services.AddSingleton(typeof(ICacheService<>), typeof(CacheService<>));

// 3. SCOPED: Ýstemci Saat Dilimi Servisi (Kullanýcýya özel)
builder.Services.AddScoped<IClientTimeZoneService, ClientTimeZoneService>();

// 4. HOSTED SERVICE: Uygulama Baþlatma Servisi (Singleton)
// Cache'i doldurmak için uygulama baþlarken çalýþýr.
builder.Services.AddHostedService<CacheInitializer>();


// --- Uygulama Servisleri Kayýtlarý ---
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductionService, ProductionService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IUomTypeService, UomTypeService>();
builder.Services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
builder.Services.AddScoped<IPriceListService, PriceListService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IProductService, ProductService>();


//builder.Services.AddSyncfusionBlazor();


var app = builder.Build();
//Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cWWdCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpcdnVXRGVZVk12XENWYUo=");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
