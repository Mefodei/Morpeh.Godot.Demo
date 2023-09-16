namespace Morpeh.Ecs.Runtime.DemoMovement.Coomponents;

using System;
using DemoPosition.Components;
using Morpeh.Godot.Tools;
using Scellecs.Morpeh;
using Shared.Systems;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Serializable]
public sealed class UpdateMovementDurationSystem : UpdateSystem
{
    private Filter _filter;
    private Stash<DurationComponent> _durationStash;
    private Stash<DemoMovementDataComponent> _movementDurationStash;

    public override void OnAwake()
    {
        _filter = World.Filter
            .With<DurationComponent>()
            .With<DemoMovementDataComponent>()
            .Build();
        
        _durationStash = World.GetStash<DurationComponent>();
        _movementDurationStash = World.GetStash<DemoMovementDataComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            ref var durationComponent = ref _durationStash.Get(entity);
            ref var movementDurationComponent = ref _movementDurationStash.Get(entity);
            
            if(durationComponent.Value < movementDurationComponent.MovementDuration)
                continue;
            
            durationComponent.Value += deltaTime;
        }
    }
}