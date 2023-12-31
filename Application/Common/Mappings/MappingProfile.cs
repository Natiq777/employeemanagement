﻿using AutoMapper;
using System.Reflection; 

namespace Application.Common.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom);
            var types = assembly.GetExportedTypes()
                .Where(p => p.IsClass && mapFromType.IsAssignableFrom(p))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
