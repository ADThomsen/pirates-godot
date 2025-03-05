using Godot;
using System;

public partial class Interactable : Area2D
{
	[Signal]
	public delegate void OnInteractEventHandler();
	
	public void Interact()
	{
		EmitSignal(SignalName.OnInteract);
	}
}
