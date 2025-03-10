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

            if (inputVector.magnitude <= 0)
            {
                _entityAnimation.SetFloatProperty("velocity", 0f);
                return;
            }
            
            _entityAnimation.SetFloatProperty("velocity", inputVector.magnitude);
            
            Quaternion targetRotation = Quaternion.LookRotation(inputVector, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _characterController.Move(transform.forward * _speed * Time.deltaTime);
            
            
        }
    } 
}