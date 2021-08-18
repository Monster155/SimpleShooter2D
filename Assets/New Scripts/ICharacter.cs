using UnityEngine;
using Zenject;

namespace New_Scripts
{
    public class Character : MonoBehaviour
    {
        [Inject] private CharacterGuns _characterGuns;
        [Inject] private CharacterHealth _characterHealth;
        [Inject] private CharacterMovement _characterMovement;
    }
}