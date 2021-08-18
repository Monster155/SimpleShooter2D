using System;
using UnityEngine;

namespace New_Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float speed = 20f;

        private void Start()
        {
            _rigidbody.velocity = transform.up * speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}