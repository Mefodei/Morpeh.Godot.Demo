namespace Morpeh.Ecs.Runtime.DemoPosition.Components;

using System;
using Godot;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Serializable]
public struct DirectionComponent : IComponent
{
    public Vector3 Value;
}