using Game.CharacterScripts;
using UnityEngine;

namespace Game.Map.Spawner
{
    public class CTSpawner : MonoBehaviour, ISpawner
    {
        public void Spawn(Character character)
        {
            character.transform.position = transform.position;
        }
    }
}