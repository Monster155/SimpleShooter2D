using System;
using UnityEngine;

namespace Game.CharacterScripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GameObject _aimObject;

        private Vector2 _movingDirection;
        private float _rotationAngle;

        public void UpdateInput(Vector2 movingDirection, float rotationAngle)
        {
            _movingDirection = movingDirection;
            _rotationAngle = rotationAngle;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _movingDirection * speed;
            _aimObject.transform.rotation = Quaternion.Euler(0, 0, _rotationAngle);
        }
    }
}