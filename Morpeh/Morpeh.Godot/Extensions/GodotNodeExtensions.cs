namespace Morpeh.Morpeh.Godot.Extensions;

using System.Collections.Generic;
using global::Godot;

public static class GodotExtensions
{
    public static Variant GetMetaByType(Node node,Variant.Type type) 
    {
        var metas = node.GetMetaList();
        foreach (var name in metas)
        {
            var metaVariant = node.GetMeta(name);
            if(metaVariant.VariantType == type)
                return metaVariant;
        }

        return new Variant();
    }
    
    public static IEnumerable<Variant> GetMetasByType(Node node,Variant.Type type) 
    {
        var metas = node.GetMetaList();
        foreach (var name in metas)
        {
            var metaVariant = node.GetMeta(name);
            if (metaVariant.VariantType == type)
                yield return metaVariant;
        }
    }
}