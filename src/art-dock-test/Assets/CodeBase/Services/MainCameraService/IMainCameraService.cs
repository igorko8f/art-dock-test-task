using UnityEngine;

namespace CodeBase.Services.MainCameraService
{
    public interface IMainCameraService
    {
        Camera MainCamera { get; }

        Vector3 ScreenToWorldPoint(Vector3 point);
        Vector3 WorldToScreenPoint(Vector3 point);
    }
}