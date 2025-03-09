using UnityEngine;

namespace CodeBase.Services.InputService
{
    public class InputService : IInputService
    {
        private bool _isInputEnabled;
        
        public InputService()
        {
            _isInputEnabled = true;
        }
        
        public void EnableInput() => 
            _isInputEnabled = true;

        public void DisableInput() => 
            _isInputEnabled = false;

        public Vector2 GetInputVector()
        {
            if (_isInputEnabled == false)
                return Vector2.zero;
            
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}