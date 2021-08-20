using System;
using Game.CharacterScripts.Weapons;
using UnityEngine;

namespace Game.CharacterScripts
{
    public class CharacterGuns : MonoBehaviour
    {
        public event Action<Weapon> OnMainWeaponChanged;
        public event Action<Weapon> OnSecondaryWeaponChanged;

        [SerializeField] private MainFireWeapon _mainFireWeapon;
        [SerializeField] private SecondaryFireWeapon _secondaryFireWeapon;

        // [SerializeField] private KnifeFireWeapon knifeFireWeapon;

        private Weapon _currentFireWeapon;
        private bool _isFire;

        private void Awake()
        {
            _mainFireWeapon.gameObject.SetActive(false);
            _secondaryFireWeapon.gameObject.SetActive(false);

            if (_mainFireWeapon != null)
                _currentFireWeapon = _mainFireWeapon;
            else
                _currentFireWeapon = _secondaryFireWeapon
                    ;
            _currentFireWeapon.gameObject.SetActive(true);
        }

        public void UpdateInput(bool isFire)
        {
            _isFire = isFire;
        }

        private void FixedUpdate()
        {
            if (_isFire) _currentFireWeapon.Attack();
        }

        public void ResetWeapons()
        {
            _mainFireWeapon.ResetWeapon();
            _secondaryFireWeapon.ResetWeapon();
        }

        private void ChangeMainWeapon(MainFireWeapon newMainFireWeapon)
        {
            _mainFireWeapon = newMainFireWeapon;
            OnMainWeaponChanged?.Invoke(_mainFireWeapon);
        }

        private void ChangeSecondaryWeapon(SecondaryFireWeapon newSecondaryFireWeapon)
        {
            _secondaryFireWeapon = newSecondaryFireWeapon;
            OnSecondaryWeaponChanged?.Invoke(_secondaryFireWeapon);
        }
    }
}