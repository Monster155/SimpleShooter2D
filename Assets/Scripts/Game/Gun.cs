using UnityEngine;
using Zenject;

namespace Game
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _muzzleTransform;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _reloadTime;
        private float _currentReloadingTime;

        [Inject] private IInputController _inputController;

        private void Start()
        {
            _currentReloadingTime = _reloadTime;
        }

        private void Update()
        {
            _currentReloadingTime += Time.deltaTime;
            if (_inputController.IsFire && _currentReloadingTime > _reloadTime)
            {
                _currentReloadingTime = 0;
                Shoot();
            }
        }

        private void Shoot()
        {
            //TODO create fabric for bullets
            Instantiate(_bulletPrefab, _muzzleTransform.position, _muzzleTransform.rotation);
        }
    }
}