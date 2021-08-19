using UnityEngine;

namespace Game.CharacterScripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GameObject _aimObject;

        private IInputController _inputController;

        private void FixedUpdate()
        {
            _rigidbody.velocity = _inputController.MovingDirection * speed;
            _aimObject.transform.rotation =
                Quaternion.Euler(0, 0, _inputController.FindLookAngle(transform.position));
        }

        public void Init(IInputController inputController)
        {
            _inputController = inputController;
        }
    }
}