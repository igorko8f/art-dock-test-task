using UnityEngine;

namespace CodeBase.Services.MainCameraService
{
    public class MainCameraService : IMainCameraService
    {
        public Camera MainCamera => _camera;
        
        private readonly Camera _camera;
        
        public MainCameraService(Camera camera)
        {
            _camera = camera;
        }

        public Vector3 ScreenToWorldPoint(Vector3 point) => 
            _camera.ScreenToViewportPoint(point);

        public Vector3 WorldToScreenPoint(Vector3 point) => 
            _camera.WorldToScreenPoint(point);
    }
}