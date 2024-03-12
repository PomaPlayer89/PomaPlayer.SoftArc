using Microsoft.Extensions.DependencyInjection;
using PomaPlayer.SoftArc.Components.Components;
using System.Reflection;
using System.Runtime.Loader;

namespace PomaPlayer.SoftArc.Components.Extensions;

/// <summary>
/// Расширения для <see cref="IMvcBuilder"/>.
/// </summary>
public static class MvcBuilderExtension
{
    /// <summary>
    /// Добавить тег-компоненты.
    /// </summary>
    public static IMvcBuilder AddTagComponents(this IMvcBuilder builder)
    {
        var types = new List<Type>()
        {
            typeof(TextEdit),
            typeof(Select)
        };

        return AddComponents(builder, types);
    }

    private static IMvcBuilder AddComponents(IMvcBuilder builder, IEnumerable<Type> types)
    {
        foreach (var type in types)
            AddComponent(builder, type);

        return builder;
    }

    private static IMvcBuilder AddComponent(IMvcBuilder builder, Type type)
    {
        var dllPath = Assembly.GetAssembly(type)?.Location ?? throw new Exception($"Type: {type.FullName} not assembly");
        builder.AddApplicationPart(AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath));
        return builder;
    }
}
