using System;
using CodeBase.Services.ProjectResourcesProvider;
using ElRaccoone.Promises;
using UnityEngine;

namespace CodeBase.Services.WindowsManagementService.MVPBase
{
    public class ViewBase : MonoBehaviour, IResource
    {
        public Promise<ViewBase> Open() => new(OpenWindowAnimation);
        public Promise Close() => new(CloseWindowAnimation);
        
        protected virtual void OpenWindowAnimation(Action<ViewBase> resolve, Action<Exception> reject)
        {
            
        }
        
        protected virtual void CloseWindowAnimation(Action resolve, Action<Exception> reject)
        {
            
        }
    }
}