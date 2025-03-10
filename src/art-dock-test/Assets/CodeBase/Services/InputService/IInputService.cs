using UnityEngine;

namespace CodeBase.Services.InputService
{
    public interface IInputService
    {
        void EnableInput();
        void DisableInput();
        bool ValidateInput(KeyCode hotKey);
        Vector3 GetInputVector();
        
    }
}