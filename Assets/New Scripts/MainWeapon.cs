using Game;
using UnityEngine;
using Zenject;

namespace New_Scripts
{
    public class MainWeapon : Weapon
    {
        [Inject(Id = "Keyboard")] private IInputController _inputController;

        private void FixedUpdate()
        {
            if (_inputController.IsFire)
            {
                Attack();
            }
        }
    }
}