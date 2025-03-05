using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Services.ProjectResourcesProvider
{
    public interface IProjectResourcesProvider
    {
        TResource LoadResource<TResource>(string path) where TResource : Object, IResource;
        TResource LoadResource<TResource>() where TResource : Object, IResource;
        IEnumerable<TResource> LoadResources<TResource>() where TResource : Object, IResource;
    }
}