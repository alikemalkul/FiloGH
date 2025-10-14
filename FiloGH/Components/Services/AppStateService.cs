public class AppStateService
{
    private string? _direction;

    public string? Direction
    {
        get => _direction;
        set
        {
            if (_direction != value)
            {
                _direction = value;
                OnDirectionChanged?.Invoke(value ?? string.Empty);
            }
        }
    }

    public event Action<string>? OnDirectionChanged;

    public void SetDirection(string direction)
    {
        Direction = direction;
    }
}
