using Godot;
using System;

public partial class TooltipComponent : Control
{
    private static TooltipComponent _instance;
    public static TooltipComponent Instance => _instance;

    public override void _EnterTree()
    {
        if (_instance != null)
        {
            QueueFree();
        }

        _instance = this;
    }

    public void ShowInteractionHelp(string helpText)
    {
        PopupPanel popupPanel = GetNode<PopupPanel>("%InteractionHelp");
        popupPanel.Show();
    }

    public void HideInteractionHelp(string helpText)
    {
        PopupPanel popupPanel = GetNode<PopupPanel>("%InteractionHelp");
        popupPanel.Hide();
    }
}