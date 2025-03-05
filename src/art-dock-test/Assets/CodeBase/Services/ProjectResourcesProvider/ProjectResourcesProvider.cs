﻿using System.Collections.Generic;
using System.Linq;
using Codebase.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Services.ProjectResourcesProvider
{
    public class ProjectResourcesProvider: IProjectResourcesProvider
    {
        public TResource LoadResource<TResource>(string path) where TResource : Object, IResource
        {
            return Resources.LoadAll<TResource>(path).FirstOrDefault();
        }
        
        public TResource LoadResource<TResource>() where TResource : Object, IResource
        {
            return LoadResources<TResource>().FirstOrDefault();
        }
        
        public IEnumerable<TResource> LoadResources<TResource>() where TResource : Object, IResource
        {
            var path = ResourceNames.GetLocation<TResource>();
            return Resources.LoadAll<TResource>(path);
        }
    }
}