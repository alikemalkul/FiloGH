using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class SessionService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    // Constructor should have the same name as the class
   public SessionService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task SetAppStateToSession(AppState state)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        
        if (httpContext != null)
        {
            var session = httpContext.Session;
            
            if (session != null)
            {
                var jsonState = JsonSerializer.Serialize(state);
                session.SetString("AppState", jsonState);
            }
        }
        
        await Task.CompletedTask;
    }
    public void DeleteAppStateFromSession()
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        if (httpContext != null)
        {
            var session = httpContext.Session;
            session.Remove("AppState");
        }
    }
   public Task<AppState> GetAppStateFromSession()
    {
        var httpContext = _httpContextAccessor.HttpContext;

        // Check if HttpContext or Session is null
        if (httpContext == null || httpContext.Session == null)
        {
            // Handle the situation where HttpContext or Session is null
            return Task.FromResult(new AppState()); // Or throw an exception, depending on your application's logic
        }

        var session = httpContext.Session;
        var jsonState = session.GetString("AppState");

        if (jsonState == null)
        {
            return Task.FromResult(new AppState()); // Return default state if session data is not available
        }

        // Deserialize the state
        var appState = JsonSerializer.Deserialize<AppState>(jsonState);

        // Check if deserialization succeeded and appState is not null
        if (appState == null)
        {
            return Task.FromResult(new AppState()); // Return default state if deserialization failed
        }

        return Task.FromResult(appState);
    }
    public async Task SetInitalAppStateToSession(AppState state)
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            if (session != null)
            {
                var jsonState = JsonSerializer.Serialize(state);
                session.SetString("InitalAppState", jsonState);
            }
        }

        await Task.CompletedTask;
    }
    public async Task<AppState?> GetInitalAppStateFromSession()
    {
        await Task.Yield(); // This satisfies the async method requirement

        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
        {
            return null;
        }

        var session = httpContext.Session;
        if (session == null)
        {
            return null;
        }

        var jsonState = session.GetString("InitalAppState");
        if (jsonState == null)
        {
            return null;
        }

        return JsonSerializer.Deserialize<AppState>(jsonState) ?? null;
    }
}
