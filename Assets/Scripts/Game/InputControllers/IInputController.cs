using UnityEngine;

namespace Game
{
    public interface IInputController
    {
        Vector2 MovingDirection { get; }
        bool IsFire { get; }
        float FindLookAngle(Vector2 playerPosition);
    }
}