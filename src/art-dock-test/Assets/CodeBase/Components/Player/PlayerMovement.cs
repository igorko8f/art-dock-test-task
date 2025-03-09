using CodeBase.Components.Animation;
using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private EntityAnimationController _entityAnimation;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _rotationSpeed = 20f;

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
            
            _entityAnimation.SetFloatProperty("velocity", inputVector.magnitude);
            
            Vector3 move = transform.right * inputVector.x + transform.forward * inputVector.y;
            _characterController.Move(move * _speed * Time.deltaTime);
            
            Quaternion targetRotation = Quaternion.LookRotation(move);
            if (Vector3.Dot(transform.forward, move) > 0)
            {
                transform.rotation =  Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
            
        }
    } 
}