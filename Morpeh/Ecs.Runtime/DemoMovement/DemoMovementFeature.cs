namespace Morpeh.Ecs.Runtime.DemoMovement;

using System;
using Abstract;
using Coomponents;
using Scellecs.Morpeh;
using Systems;

[Serializable]
public class DemoMovementFeature : IMorpehFeature
{
    public World Register(World world)
    {
        var systemGroup = world.CreateSystemsGroup();
        systemGroup.AddSystem(new UpdateMovementDirectionSystem());
        systemGroup.AddSystem(new UpdateMovementPositionSystem());
        systemGroup.AddSystem(new UpdateMovementDurationSystem());

        return world;
    }
}