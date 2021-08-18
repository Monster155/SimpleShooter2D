using System;
using UnityEngine;

namespace New_Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private Transform _muzzleTransform;
        // [SerializeField] private Transform _bulletsContainerTransform; // TODO bullets container

        [Space(10f)] [SerializeField] [Tooltip("Weapon's bullets damage")]
        private int _damage = 10;

        [SerializeField] [Tooltip("Bullets count for burst shooting (0 - for infinity count)")]
        private int _bulletsCountInQueue = 3;

        [SerializeField] [Tooltip("Bullets count in weapon clip (0 - for infinity count)")]
        private int _ammoInClipCount = 30;

        [SerializeField] [Tooltip("Bullets count which uses for reloading (0 - for infinity count)")]
        private int _leftAmmoCount = 90;

        [SerializeField] [Tooltip("Time in seconds between shots")]
        private float _fireRateInSeconds = 0.1f;

        [SerializeField] [Tooltip("Time in seconds for clip filling")]
        private float _reloadTime = 3f;

        [SerializeField] [Tooltip("Time is seconds between two queues")]
        private float _queueReloadTime = 0.5f;

        private int _currentBulletsCountInQueue;
        private int _currentAmmoInClipCount;
        private int _currentLeftAmmoCount;
        private float _currentFireRateInSeconds;
        private float _currentReloadTime;
        private float _currentQueueReloadTime;

        /// <summary>Weapon's bullets damage</summary>
        public int GetDamage => _damage;

        /// <summary>Bullets count for burst shooting</summary>
        public int GetBulletsCountInQueue => _bulletsCountInQueue;

        /// <summary>Bullets count in weapon clip</summary>
        public int GetAmmoInClipCount => _ammoInClipCount;

        /// <summary>Bullets count which uses for reloading</summary>
        public int GetLeftAmmoCount => _leftAmmoCount;

        /// <summary>Time in seconds between shots</summary>
        public float GetFireRateInSeconds => _fireRateInSeconds;

        /// <summary>Time in seconds for clip filling</summary>
        public float GetReloadTime => _reloadTime;

        /// <summary>Time is seconds between two queues</summary>
        public float GetQueueReloadTime => _queueReloadTime;

        protected virtual void Awake()
        {
            _currentBulletsCountInQueue = _bulletsCountInQueue;
            _currentAmmoInClipCount = _ammoInClipCount;
            _currentLeftAmmoCount = _leftAmmoCount;
            _currentFireRateInSeconds = _fireRateInSeconds;
            _currentReloadTime = _reloadTime;
            _currentQueueReloadTime = _queueReloadTime;
        }

        protected virtual void Attack()
        {
            // check is clip empty
            if (_currentAmmoInClipCount > 0 || _ammoInClipCount == 0)
            {
                // if clip isn't empty, check is queue has bullets
                if (_currentBulletsCountInQueue > 0 || _bulletsCountInQueue == 0)
                {
                    // if queue has bullets, calculating fare rate
                    UpdateReloadingTime(ref _currentFireRateInSeconds);
                    if (_currentFireRateInSeconds <= 0)
                    {
                        Debug.Log("Bullet spawned");
                        _currentFireRateInSeconds = _fireRateInSeconds;
                        _currentBulletsCountInQueue--;
                        _currentAmmoInClipCount--;
                        // TODO send bullet
                        Bullet bullet = Instantiate(_bulletPrefab,
                            _muzzleTransform.position, _muzzleTransform.rotation);
                    }
                }
                else
                {
                    // if queue left all bullets - reload queue
                    UpdateReloadingTime(ref _currentQueueReloadTime);
                    if (_currentQueueReloadTime <= 0)
                    {
                        Debug.Log("Queue reloading...");
                        _currentQueueReloadTime = _queueReloadTime;
                        _currentBulletsCountInQueue = _bulletsCountInQueue;
                    }
                }
            }
            else
            {
                // if clip is empty, check is has left ammo
                if (_currentLeftAmmoCount > 0 || _leftAmmoCount == 0)
                {
                    //if left ammo not zero, do reloading
                    UpdateReloadingTime(ref _currentReloadTime);
                    if (_currentReloadTime <= 0)
                    {
                        Debug.Log("Reloading...");
                        _currentReloadTime = _reloadTime;
                        _currentBulletsCountInQueue = _bulletsCountInQueue;
                        if (_currentLeftAmmoCount - _ammoInClipCount > 0)
                        {
                            _currentAmmoInClipCount = _ammoInClipCount;
                            _currentLeftAmmoCount -= _currentAmmoInClipCount;
                        }
                        else
                        {
                            _currentAmmoInClipCount = _currentLeftAmmoCount;
                            _currentLeftAmmoCount = 0;
                        }
                    }
                }
                else
                {
                    // if clip is empty and left ammo is empty - it's "fiasko, bratan"
                    Debug.Log("Empty Ammo: fiasko, bratan");
                }
            }
        }

        private void UpdateReloadingTime(ref float time)
        {
            time -= Time.fixedDeltaTime;
            Debug.Log(Time.fixedDeltaTime);
        }

        private void SpawnBullet()
        {
        }

        private void Fire()
        {
        }

        private void ReloadQueue()
        {
        }

        private void Reload()
        {
        }

        private void EmptyAmmo()
        {
            // TODO empty ammo
        }
    }
}