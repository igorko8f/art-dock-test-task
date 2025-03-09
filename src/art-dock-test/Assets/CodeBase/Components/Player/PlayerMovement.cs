using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private IInputService _inputService;
        private CharacterController _characterController;
        private Vector3 _velocity;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var inputVector = _inputService.GetInputVector();
            
            if (inputVector.magnitude <= 0) return;
            
            Vector3 move = transform.right * inputVector.x + transform.forward * inputVector.y;
            _characterController.Move(move * _speed * Time.deltaTime);
        }
    } 
}