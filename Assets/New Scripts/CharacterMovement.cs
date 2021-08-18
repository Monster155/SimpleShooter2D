using Game;
using UnityEngine;
using Zenject;

namespace New_Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GameObject _aimObject;

        [Inject] private IInputController _inputController;

        private void FixedUpdate()
        {
            _rigidbody.velocity = _inputController.MovingDirection * speed;
            _aimObject.transform.rotation =
                Quaternion.Euler(0, 0, _inputController.ShootingDirection(transform.position));
        }
    }
}