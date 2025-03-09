using UnityEngine;

namespace CodeBase.Services.InputService
{
    public interface IInputService
    {
        void EnableInput();
        void DisableInput();
        
        Vector2 GetInputVector();
        
    }
}