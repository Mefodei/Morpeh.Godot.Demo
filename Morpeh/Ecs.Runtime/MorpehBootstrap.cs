namespace Morpeh.Ecs.Runtime;

using System;
using System.Collections.Generic;
using Abstract;
using DemoMovement;
using Godot;
using Scellecs.Morpeh;

[Serializable]
public class MorpehBootstrap : IDisposable 
{
    private List<IMorpehFeature> _features = new List<IMorpehFeature>()
    {
        new DemoMovementFeature(),
        new DemoRotationFeature()
    };
    
    private World _world;

    public World World { get; set; }
    
    #region public methods
    
    public void Update(double delta)
    {
        //manually world updates
        _world.Update((float)delta);
        
        //apply all entity changes, filters will be updated.
        //automatically invoked between systems
        _world.Commit();
    }

    public void FixedUpdate()
    {
        _world.FixedUpdate(Time.GetTicksMsec());
    }

    public void Dispose()
    {
        _world?.Dispose();
        _world = null;
    }
    
    public void Initialize()
    {
        if(_world != null)
            return;
        
        _world = World.Create();
        _world.UpdateByUnity = false;

        World = _world;
        InitializeSystems(_world);
    }
    
    #endregion

    private void InitializeSystems(World world)
    {
        foreach (var morpehFeature in _features)
        {
            morpehFeature.Register(world);
        }
    }

}