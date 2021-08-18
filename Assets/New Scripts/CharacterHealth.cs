using System;
using UnityEngine;

namespace New_Scripts
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] [Tooltip("Maximum character Health Points")]
        private int _maxHP = 100;

        [SerializeField] [Tooltip("Maximum character Armor points")]
        private int _maxArmor = 100;

        private int _currentHP;
        private int _currentArmor;

        private void Awake()
        {
            _currentHP = _maxHP;
            _currentArmor = _maxArmor;
        }

        private void GetDamage(int damageCount)
        {
            CalculateDamage(ref damageCount, ref _currentArmor);
            CalculateDamage(ref damageCount, ref _currentHP);

            if (_currentHP <= 0)
            {
                Debug.Log("You dead");
            }
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
    }
}