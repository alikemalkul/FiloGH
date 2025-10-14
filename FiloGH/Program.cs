// Gerekli using'ler buraya eklenmeli (FiloGH.Application.Services.Abstract ve FiloGH.Infrastructure.Services)
using BlazorColorPicker;
using FiloGH.Application.Interfaces;
using FiloGH.Application.Services;
using FiloGH.Application.Services.Abstract;
using FiloGH.Application.Services.Concrete;
using FiloGH.Components;
using FiloGH.Core.Interfaces;
using FiloGH.Infrastructure.Data.Contexts; // DbContext i�in
using FiloGH.Infrastructure.Repositories; // UnitOfWork ve GenericRepository i�in
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


// 1. SCOPED: Veri Eri�im Y�netimi (Unit of Work)
// Her HTTP iste�i/Blazor devresi i�in ayr� bir UoW/DbContext �rne�i olu�turulur.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// !!! KR�T�K DE����KL�K: TId deste�ini eklemek i�in Repository kayd�n� g�ncelliyoruz.
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
// 2. SINGLETON: �nbellek Servisi (Uygulama ya�am� boyunca tek)
// T�m uygulama katmanlar�, tek bir Cache Service �rne�ini kullan�r.
builder.Services.AddSingleton(typeof(ICacheService<>), typeof(CacheService<>));

// 3. SCOPED: �stemci Saat Dilimi Servisi (Kullan�c�ya �zel)
builder.Services.AddScoped<IClientTimeZoneService, ClientTimeZoneService>();

// 4. HOSTED SERVICE: Uygulama Ba�latma Servisi (Singleton)
// Cache'i doldurmak i�in uygulama ba�larken �al���r.
builder.Services.AddHostedService<CacheInitializer>();


// --- Uygulama Servisleri Kay�tlar� ---
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
