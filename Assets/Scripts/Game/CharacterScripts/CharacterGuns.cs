using System;
using Game.CharacterScripts.Weapons;
using UnityEngine;

namespace Game.CharacterScripts
{
    public class CharacterGuns : MonoBehaviour
    {
        [SerializeField] private MainFireWeapon _mainFireWeapon;
        [SerializeField] private SecondaryFireWeapon _secondaryFireWeapon;

        // [SerializeField] private KnifeFireWeapon knifeFireWeapon;

        private Weapon _currentFireWeapon;
        private IInputController _inputController;

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

        private void FixedUpdate()
        {
            if (_inputController.IsFire) _currentFireWeapon.Attack();
        }

        public event Action<Weapon> OnMainWeaponChanged;
        public event Action<Weapon> OnSecondaryWeaponChanged;

        public void Init(IInputController inputController)
        {
            _inputController = inputController;
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