using System.Reflection;
using AutoMapper;

namespace OnlineShop.Application.Common.Mappings;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t
                .GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToArray();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Map") 
                ?? type.GetInterface("IMapFrom`1")?.GetMethod("Map");

            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
