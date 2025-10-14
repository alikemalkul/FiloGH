public class NavScrollService
{
      public event Action<string>? ScrollModeChanged;
    
    private string? isMenuType = "";

    public string? IsMenuType 
    { 
        get => isMenuType; 
        set 
        {
            if (isMenuType != value)
            {
                isMenuType = value;
                ScrollModeChanged?.Invoke(isMenuType ?? throw new ArgumentNullException(nameof(isMenuType)));
            }
        }
    }
    public event Action<bool>? VerticalModeChanged;
    
    private bool isVertical = true;

    public bool IsVertical 
    { 
        get => isVertical; 
        set 
        {
            if (isVertical != value)
            {
                isVertical = value;
                VerticalModeChanged?.Invoke(isVertical);
            }
        }
    }
}