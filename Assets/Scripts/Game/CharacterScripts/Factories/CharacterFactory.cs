using System;
using Game.Map.Spawner;
using UnityEngine;
using Zenject;

namespace Game.CharacterScripts.Factories
{
    public class CharacterFactory : MonoBehaviour
    {
        [Inject] private readonly IInputController _inputController;

        public CharacterFactory(IInputController inputController)
        {
            _inputController = inputController;
        }

        public Character CreateCharacter(GameObject characterPrefab, bool isRed, Action onDeadAction)
        {
            Character character = Instantiate(characterPrefab).GetComponent<Character>();
            character.Init(isRed, _inputController);
            character.OnCharacterDead += onDeadAction;
            return character;
        }

        public Character ResetCharacter(Character character, ISpawner spawner)
        {
            character.ResetCharacter();
            spawner.Spawn(character);
            return character;
        }
    }
}