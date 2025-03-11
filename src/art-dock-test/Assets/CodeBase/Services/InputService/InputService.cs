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

        public Vector3 GetInputVector()
        {
            if (_isInputEnabled == false)
                return Vector3.zero;
            
            return new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")).normalized;
        }

        public bool ValidateInput(KeyCode hotKey)
        {
            if (_isInputEnabled == false) return false;
            return Input.GetKeyDown(hotKey);
        }
    }
}