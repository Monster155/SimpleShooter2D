using UnityEngine;

namespace Game
{
    public class AIInputController : IInputController
    {
        public Vector2 MovingDirection => Vector2.zero;

        public bool IsFire => true;

        public float FindLookAngle(Vector2 playerPosition)
        {
            return 90f;
        }
    }
}