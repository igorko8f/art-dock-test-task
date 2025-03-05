using CodeBase.Services.ProjectResourcesProvider;
using CodeBase.Services.WindowsManagementService.MVPBase;
using Codebase.StaticData;

namespace CodeBase.Services.WindowsManagementService
{
    public interface IWindowsManagementService
    {
        TPresenter CreateWindow<TPresenter, TView, TModel>(UILayer layer, TModel model)
            where TPresenter : PresenterBase
            where TView : ViewBase, IResource
            where TModel : ModelBase;
    }
}