using System;
using Game.CharacterScripts.Weapons;
using UnityEngine;

namespace Game.CharacterScripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterGuns _characterGuns;
        [SerializeField] private CharacterHealth _characterHealth;
        [SerializeField] private CharacterMovement _characterMovement;

        public CharacterHealth GetCharacterHealth => _characterHealth;

        private void OnEnable()
        {
            _characterHealth.OnPointsChanged += CharacterHealth_OnPointsChanged;
            _characterGuns.OnMainWeaponChanged += CharacterGuns_OnMainWeaponChanged;
            _characterGuns.OnSecondaryWeaponChanged += CharacterGuns_OnSecondaryWeaponChanged;
        }

        private void OnDisable()
        {
            _characterHealth.OnPointsChanged -= CharacterHealth_OnPointsChanged;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherTransform = other.transform;
            if (otherTransform.tag.Equals("Bullet"))
                _characterHealth.GetDamage(otherTransform.GetComponent<Bullet>().Damage);
        }

        public event Action OnCharacterDead;
        public event Action<WeaponSlot, Weapon> OnWeaponChanged;

        public void UpdateInput(Vector2 movingDirection, float rotationAngle, bool isFire)
        {
            _characterMovement.UpdateInput(movingDirection, rotationAngle);
            _characterGuns.UpdateInput(isFire);
        }

        private void CharacterHealth_OnPointsChanged(int newHP, int newArmor)
        {
            if (newHP <= 0) OnCharacterDead?.Invoke();
        }

        public void ResetCharacter()
        {
            _characterGuns.ResetWeapons();
            _characterHealth.ResetHealth();
            // _characterMovement - nothing to reset
        }

        private void CharacterGuns_OnSecondaryWeaponChanged(Weapon weapon)
        {
            OnWeaponChanged?.Invoke(WeaponSlot.MAIN, weapon);
        }

        private void CharacterGuns_OnMainWeaponChanged(Weapon weapon)
        {
            OnWeaponChanged?.Invoke(WeaponSlot.SECONDARY, weapon);
        }
    }

    public enum WeaponSlot
    {
        MAIN,
        SECONDARY,
        KNIFE
    }
}