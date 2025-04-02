using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Interactor : Area2D
{
	public List<Interactable> Interactables = new List<Interactable>();
	public Interactable CurrentInteractable;
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		CurrentInteractable = Interactables.MinBy(x => GlobalPosition.DistanceTo(x.GlobalPosition));
		if (Input.IsActionJustPressed("Interact"))
		{
			if (CurrentInteractable != null)
			{
				CurrentInteractable.Interact();
			}
		}
		if (CurrentInteractable != null)
		{
			TooltipComponent.Instance.ShowInteractionHelp(CurrentInteractable.InteractionText);
		}
		else
		{
			TooltipComponent.Instance.HideInteractionHelp();
		}
	}

	public void OnAreaEntered(Node2D node)
	{
		if (node is Interactable interactable)
		{
			Interactables.Add(interactable);
		}
	}

	public void OnAreaExited(Node2D node)
	{
		if (node is Interactable interactable)
		{
			
			Interactables.Remove(interactable);
		}
	}
}
