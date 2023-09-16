namespace Morpeh.Runtime;

using System;
using Ecs.Runtime;
using Ecs.Runtime.DemoMovement.Components;
using Ecs.Runtime.DemoMovement.Coomponents;
using Ecs.Runtime.DemoPosition.Components;
using Godot;
using Morpeh.Godot.Tools;
using Scellecs.Morpeh;

[Serializable]
public partial class BootstrapNode : Node
{
	private MorpehBootstrap _morpehBootstrap;
	private bool _initialized;

	[Export] public int amount;
	[Export] public Resource item;
	[Export] public Vector2 speedLimit = new Vector2(0.1f, 10f);
	[Export] public float spawnRadius = 100f;
	[Export] public Vector2 duration = new Vector2(3f, 10f);
	[Export] public Vector2 rotation = new Vector2(1f, 30f);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitializeMorpeh();	
		InitializeEntities();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!_initialized) return;

		_morpehBootstrap.Update(delta);
	}

	private void InitializeMorpeh()
	{
		_morpehBootstrap = new MorpehBootstrap();
		_morpehBootstrap.Initialize();
	}

	private void InitializeEntities()
	{
		if (string.IsNullOrEmpty(item.ResourcePath))
			return;
		
		GD.Print($"CREATE ENTITY == {amount}");
		
		var resourceNode = GD.Load<PackedScene>(item.ResourcePath);
		
		for (var i = 0; i < amount; i++)
		{
			var itemNode = resourceNode.Instantiate<Node3D>(PackedScene.GenEditState.Instance);

			itemNode.Position = RandomTool.NextVector3(-spawnRadius, spawnRadius);
			itemNode.Rotation = RandomTool.NextVector3(-spawnRadius, spawnRadius);
			
			AddChild(itemNode);
			
			Convert(itemNode);
		}
	}

	private void Convert(Node3D node)
	{
		var world = _morpehBootstrap.World;
		var entity = world.CreateEntity();
		
		ref var node3DComponent = ref entity.AddComponent<Node3DComponent>();
		ref var speedComponent = ref entity.AddComponent<SpeedComponent>();
		ref var directionComponent =ref entity.AddComponent<DirectionComponent>();
		ref var rotationComponent = ref entity.AddComponent<RotationComponent>();
		ref var durationComponent = ref entity.AddComponent<DurationComponent>();
		ref var demoMovementDurationComponent = ref entity.AddComponent<DemoMovementDataComponent>();
		ref var rotationDataComponent = ref entity.AddComponent<DemoRotationDataComponent>();

		node3DComponent.Value = node;
		demoMovementDurationComponent.MovementDuration = RandomTool.NextFloat(duration.X, duration.Y);	
		speedComponent.Value = RandomTool.NextFloat(speedLimit.X, speedLimit.Y);
		directionComponent.Value = RandomTool.NextVector3(-1f, 1f);
		rotationComponent.Value = RandomTool.NextVector3(speedLimit.X, speedLimit.Y);
		rotationDataComponent.Value = RandomTool.NextFloat(rotation.X, rotation.Y);
		durationComponent.Value = 0f;
	}
}
