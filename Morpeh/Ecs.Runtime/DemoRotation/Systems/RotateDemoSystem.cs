namespace Morpeh.Ecs.Runtime.DemoRotation.Systems;

using System;
using DemoMovement.Components;
using DemoPosition.Components;
using Scellecs.Morpeh;
using Shared.Systems;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Serializable]
public sealed class RotateDemoSystem : UpdateSystem
{
    private Filter _filter;
    private Stash<Node3DComponent> _nodeStash;
    private Stash<RotationComponent> _rotationStash;
    private Stash<DemoRotationDataComponent> _dataStash;

    public override void OnAwake()
    {
        _filter = World.Filter
            .With<Node3DComponent>()
            .With<DemoRotationDataComponent>()
            .With<RotationComponent>()
            .Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            ref var nodeComponent = ref _nodeStash.Get(entity);
            ref var rotationComponent = ref _rotationStash.Get(entity);
            ref var rotationDataComponent = ref _dataStash.Get(entity);
            nodeComponent.Value.Rotate(rotationComponent.Value, rotationDataComponent.Value * deltaTime);
        }
    }
}