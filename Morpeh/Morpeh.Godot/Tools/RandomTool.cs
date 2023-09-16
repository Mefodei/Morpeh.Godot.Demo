namespace Morpeh.Morpeh.Godot.Tools;

using System.Runtime.CompilerServices;
using global::Godot;

public static class RandomTool
{
    private static RandomNumberGenerator _random;
    
    static RandomTool()
    {
        _random = new RandomNumberGenerator();
        _random.Randomize();
    }

    public static void SetSeed(ulong seed)
    {
        _random.Seed = seed;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float NextFloat(float from,float to)
    {
        return _random.RandfRange(from, to);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 NextVector3(float from,float to)
    {
        return new Vector3(_random.RandfRange(from, to), 
            _random.RandfRange(from, to), 
            _random.RandfRange(from, to));
    }
}