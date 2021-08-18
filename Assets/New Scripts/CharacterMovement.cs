using Game;
using UnityEngine;
using Zenject;

namespace New_Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [Inject] private IInputController _inputController;
    }
}