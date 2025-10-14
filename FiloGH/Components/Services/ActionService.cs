// ActionService.cs
using System;

public interface IActionService
{
    event Action<string> OnActionTriggered;
    void TriggerAction(string actionValue);
}

public class ActionService : IActionService
{
    public event Action<string>? OnActionTriggered;

    public void TriggerAction(string actionValue)
    {
        OnActionTriggered?.Invoke(actionValue);
    }
}
