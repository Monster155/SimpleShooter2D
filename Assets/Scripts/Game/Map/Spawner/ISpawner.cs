using UnityEngine;

namespace Game.Map.Spawner
{
    public interface ISpawner
    {
        void Spawn(Vector2 pos);
    }
}