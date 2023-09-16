namespace Morpeh.Ecs.Runtime.DemoMovement.Systems;

using System;
using Coomponents;
using DemoPosition.Components;
using Godot;
using Scellecs.Morpeh;
using Shared.Systems;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Serializable]
public sealed class UpdateMovementPositionSystem : UpdateSystem
{
    private Filter _filter;
    private Stash<Node3DComponent> _node3DStash;
    private Stash<DirectionComponent> _directionStash;
    private Stash<SpeedComponent> _speedStash;

    public override void OnAwake()
    {
        _filter = World.Filter
            .With<DirectionComponent>()
            .With<Node3DComponent>()
            .With<DemoMovementDataComponent>()
            .With<SpeedComponent>()
            .Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            ref var speedComponent = ref _speedStash.Get(entity);
            ref var nodeComponent = ref _node3DStash.Get(entity);
            ref var directionComponent = ref _directionStash.Get(entity);

            var node = nodeComponent.Value;
            var offset = deltaTime * speedComponent.Value * directionComponent.Value;
            node.Position = node.Position + offset;
        }
    }
}