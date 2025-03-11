using System.Collections;
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
        
        public IEnumerator RotateByAngle(float angle, float duration)
        {
            Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, angle, 0);
            yield return RotateToTargetRotation(targetRotation, duration);
        }
        
        public IEnumerator RotateToTargetPosition(Vector3 targetPosition, float duration)
        {
            
            Vector3 direction = (targetPosition - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            yield return RotateToTargetRotation(targetRotation, duration);
        }

        private IEnumerator RotateToTargetRotation(Quaternion targetRotation, float duration)
        {
            Quaternion startRotation = transform.rotation;
            
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = targetRotation;
        }
    } 
}