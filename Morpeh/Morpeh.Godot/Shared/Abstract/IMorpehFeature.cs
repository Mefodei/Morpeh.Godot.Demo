namespace Morpeh.Ecs.Runtime.Abstract;

using Scellecs.Morpeh;

public interface IMorpehFeature
{
    World Register(World world,SystemsGroup group);
}