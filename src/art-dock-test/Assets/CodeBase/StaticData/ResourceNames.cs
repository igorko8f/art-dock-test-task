using System;
using CodeBase.Components.Enemy;
using CodeBase.Components.Player;
using CodeBase.Services.ProjectResourcesProvider;

namespace Codebase.StaticData
{
    public static class ResourceNames
    {
        //Declare resources 
        private static ResourceName[] resources =
        {
            new (typeof(EnemyBase), "Prefabs/"),
            new (typeof(PlayerBase), "Prefabs/")
        };

        public static string GetLocation<TResource>() where TResource : IResource
        {
            var location = string.Empty;
            foreach (var resource in resources)
            {
                if (resource.Type == typeof(TResource))
                    location = resource.Location;
            }

            if (string.IsNullOrEmpty(location))
                throw new NullReferenceException($"The is no path for resource with type {typeof(TResource)}.");

            return location;
        }
    }
}