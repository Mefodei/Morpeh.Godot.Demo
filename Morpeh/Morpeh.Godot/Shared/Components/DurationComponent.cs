namespace Morpeh.Ecs.Runtime.DemoPosition.Components;

using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Serializable]
public struct DurationComponent : IComponent
{
    public float Value;
}