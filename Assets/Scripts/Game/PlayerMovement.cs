using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _movingSpeed = 10f;
        [SerializeField] private GameObject _playerModel;

        [Inject] private IInputController _inputController;

        private void FixedUpdate()
        {
            _rigidbody.velocity = _inputController.MovingDirection * _movingSpeed;
            _playerModel.transform.rotation =
                Quaternion.Euler(0, 0, _inputController.ShootingDirection(transform.position));
        }
    }
}