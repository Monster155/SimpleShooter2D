using UnityEngine;

namespace Game.CharacterScripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Attack();

        public abstract void ResetWeapon();
    }
}