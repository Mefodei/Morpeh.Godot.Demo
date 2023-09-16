namespace Morpeh.Ecs.Runtime.DemoMovement.Coomponents;

using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Serializable]
public struct DemoMovementDataComponent : IComponent
{
    public float MovementDuration;
}