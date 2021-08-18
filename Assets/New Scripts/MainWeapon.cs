using Game;
using UnityEngine;
using Zenject;

namespace New_Scripts
{
    public class MainWeapon : Weapon
    {
        [Inject] private IInputController _inputController;

        private void FixedUpdate()
        {
            if (_inputController.IsFire)
            {
                Attack();
            }
        }
    }
}