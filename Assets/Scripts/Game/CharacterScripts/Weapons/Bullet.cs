using System;
using UnityEngine;

namespace Game.CharacterScripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float speed = 20f;

        public int Damage { get; private set; }

        private void Start()
        {
            _rigidbody.velocity = transform.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }

        public void Init(int damage)
        {
            Damage = damage;
        }
    }
}