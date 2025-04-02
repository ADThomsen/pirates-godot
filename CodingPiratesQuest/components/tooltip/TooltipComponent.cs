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
        Label helpLabel = popupPanel.GetNode<Label>("%HelpText");
        helpLabel.Text = helpText;
        popupPanel.Show();
    }

    public void HideInteractionHelp()
    {
        PopupPanel popupPanel = GetNode<PopupPanel>("%InteractionHelp");
        popupPanel.Hide();
    }
}