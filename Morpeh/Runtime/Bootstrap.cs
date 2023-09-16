namespace Morpeh.Runtime;

using Ecs.Runtime;
using Godot;


public partial class Bootstrap : Node
{
	private MorpehBootstrap _morpehBootstrap;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_morpehBootstrap = new MorpehBootstrap();
		_morpehBootstrap.Initialize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_morpehBootstrap.Update(delta);
	}
}