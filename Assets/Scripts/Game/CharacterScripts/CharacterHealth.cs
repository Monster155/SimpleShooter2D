using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.CharacterScripts
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] [Tooltip("Maximum character Health Points")]
        private int _maxHP = 100;

        [SerializeField] [Tooltip("Maximum character Armor points")]
        private int _maxArmor = 100;

        [SerializeField] private Image _healthBar;
        [SerializeField] private Image _armorBar;
        private int _currentArmor;

        private int _currentHP;

        public int CurrentHP => _currentHP;
        public int CurrentArmor => _currentArmor;

        private void Awake()
        {
            ResetHealth();
        }

        public event Action<int, int> OnPointsChanged; // HP, armor

        public void GetDamage(int damageCount)
        {
            CalculateDamage(ref damageCount, ref _currentArmor);
            _armorBar.fillAmount = (float) _currentArmor / _maxArmor;
            CalculateDamage(ref damageCount, ref _currentHP);
            _healthBar.fillAmount = (float) _currentHP / _maxHP;

            if (_currentHP <= 0) Debug.Log("You dead");
            OnPointsChanged?.Invoke(_currentHP, _currentArmor);
        }

        private void IncreaseHP(int addPoints)
        {
            _currentHP = _currentHP + addPoints > _maxHP ? _maxHP : _currentHP + addPoints;
        }

        private void IncreaseArmor(int addPoints)
        {
            _currentArmor = _currentArmor + addPoints > _maxArmor ? _maxArmor : _currentArmor + addPoints;
        }

        private void CalculateDamage(ref int damageLeft, ref int counter)
        {
            if (counter - damageLeft > 0)
            {
                counter -= damageLeft;
                damageLeft = 0;
            }
            else
            {
                damageLeft -= counter;
                counter = 0;
            }
        }

        public void ResetHealth()
        {
            _currentHP = _maxHP;
            _currentArmor = _maxArmor;
        }
    }
}