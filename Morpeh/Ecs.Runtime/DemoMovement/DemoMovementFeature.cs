namespace Morpeh.Ecs.Runtime.DemoMovement;

using System;
using Abstract;
using Coomponents;
using Scellecs.Morpeh;
using Systems;

[Serializable]
public class DemoMovementFeature : IMorpehFeature
{
    public World Register(World world,SystemsGroup group)
    {
        group.AddSystem(new UpdateMovementDirectionSystem());
        group.AddSystem(new UpdateMovementPositionSystem());
        group.AddSystem(new UpdateMovementDurationSystem());

        
        
        return world;
    }
}