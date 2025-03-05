using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Services.ProjectResourcesProvider;
using CodeBase.Services.WindowsManagementService.MVPBase;
using Codebase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.WindowsManagementService
{
    public class WindowsManagementService : MonoBehaviour, IWindowsManagementService
    {
        private const string WindowResourcesPath = "UI/";
        
        [SerializeField] private UILayerInfo[] _layers;

        private Dictionary<UILayer, PresenterBase> _currentOpenedWindows = new ();
        
        private IProjectResourcesProvider _resourcesProvider;
        private IInstantiator _instantiator;

        [Inject]
        public void Construct(IProjectResourcesProvider resourcesProvider, IInstantiator instantiator)
        {
            _resourcesProvider = resourcesProvider;
            _instantiator = instantiator;
        }

        public TPresenter CreateWindow<TPresenter, TView, TModel>(UILayer layer, TModel model) 
            where TPresenter : PresenterBase 
            where TView : ViewBase, IResource
            where TModel : ModelBase
        {
            CloseAllWindowsOnLayer(layer);

            var viewResource = _resourcesProvider.LoadResource<TView>(WindowResourcesPath);
            if (viewResource is null)
            {
                throw new Exception($"There is no resource {typeof(TView)} in folder Resources/{WindowResourcesPath}");
            }

            var view = _instantiator.InstantiatePrefab(viewResource, GetParentByLayer(layer));
            return _instantiator.Instantiate<TPresenter>(new object[] { model, view });
        }

        private Transform GetParentByLayer(UILayer layer)
        {
            var layerInfo = _layers.FirstOrDefault(x => x.Layer == layer);
            return layerInfo?.Parent;
        }

        private void CloseAllWindowsOnLayer(UILayer layer)
        {
            if (_currentOpenedWindows.ContainsKey(layer) == false) return;
            var currentWindowOnLayer = _currentOpenedWindows[layer];
            currentWindowOnLayer.Dispose();

            _currentOpenedWindows.Remove(layer);
        }
    }
}