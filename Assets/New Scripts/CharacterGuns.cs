using UnityEngine;
using Zenject;

namespace New_Scripts
{
    public class CharacterGuns : MonoBehaviour
    {
        [Inject] private MainWeapon _mainWeapon;
        [Inject] private SecondaryWeapon _secondaryWeapon;
        [Inject] private KnifeWeapon _knifeWeapon;
    }
}