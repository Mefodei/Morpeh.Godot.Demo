namespace Morpeh.Ecs.Runtime.DemoMovement;

using System;
using Abstract;
using DemoRotation.Systems;
using Scellecs.Morpeh;

[Serializable]
public class DemoRotationFeature : IMorpehFeature
{
    public World Register(World world,SystemsGroup group)
    {
        group.AddSystem(new RotateDemoSystem());
        return world;
    }
}