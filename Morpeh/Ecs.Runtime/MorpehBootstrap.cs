namespace Morpeh.Ecs.Runtime;

using System;
using System.Collections.Generic;
using Abstract;
using Godot;
using Scellecs.Morpeh;

[Serializable]
public class MorpehBootstrap : IDisposable 
{
    private List<IMorpehFeature> _features = new List<IMorpehFeature>();
    private World _world;

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

        InitializeSystems(_world);
    }
    
    #endregion

    private void InitializeSystems(World world)
    {
        
    }

}