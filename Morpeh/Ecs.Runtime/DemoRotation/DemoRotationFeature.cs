namespace Morpeh.Ecs.Runtime.DemoMovement;

using System;
using Abstract;
using Coomponents;
using DemoRotation.Systems;
using Scellecs.Morpeh;
using Systems;

[Serializable]
public class DemoRotationFeature : IMorpehFeature
{
    public World Register(World world)
    {
        var systemGroup = world.CreateSystemsGroup();
        systemGroup.AddSystem(new RotateDemoSystem());

        return world;
    }
}