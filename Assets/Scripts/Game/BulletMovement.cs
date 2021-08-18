using UnityEngine;

namespace Game
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float speed = 50f;

        private void Start()
        {
            _rigidbody.velocity = transform.up * speed;
        }
    }
}