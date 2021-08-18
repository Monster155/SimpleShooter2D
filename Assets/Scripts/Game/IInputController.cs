using UnityEngine;

namespace Game
{
    public interface IInputController
    {
        Vector2 MovingDirection { get; }
        float ShootingDirection(Vector2 playerPosition);
        bool IsFire { get; }
    }
}