using Godot;
using System;

public partial class Interactable : Area2D
{
	[Export]
	public string InteractionText { get; set; }
	
	[Signal]
	public delegate void OnInteractEventHandler();
	
	public void Interact()
	{
		EmitSignal(SignalName.OnInteract);
	}
}
