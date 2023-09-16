namespace Morpeh.Ecs.Runtime.Shared.Systems;

using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public class UpdateSystem : ISystem
{
    public World World { get; set; }
    
    public virtual void OnAwake()
    {
        
    }

    public virtual void OnUpdate(float deltaTime) 
    {
        
    }

    public virtual void Dispose()
    {
        
    }
}