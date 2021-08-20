using UnityEngine;
using Zenject;

namespace Game
{
    public class KeyboardController : IInputController
    {
        [Inject] private Camera _mainCamera;

        public KeyboardController()
        {
            _mainCamera = _mainCamera == null ? Camera.main : _mainCamera;
        }

        public Vector2 MovingDirection
        {
            // float x = Input.GetAxis("Horizontal");
            // float y = Input.GetAxis("Vertical");
            get
            {
                int x = 0, y = 0;
                if (Input.GetKey(KeyCode.A))
                    x = -1;
                else if (Input.GetKey(KeyCode.D))
                    x = 1;

                if (Input.GetKey(KeyCode.W))
                    y = 1;
                else if (Input.GetKey(KeyCode.S))
                    y = -1;

                if (x != 0 && y != 0)
                    return new Vector2(x * 0.7f, y * 0.7f);

                return new Vector2(x, y);
            }
        }

        public float FindLookAngle(Vector2 playerPosition)
        {
            Debug.Log("Cam: " + _mainCamera);
            Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var angle = Vector2.SignedAngle(Vector2.up, mousePos - playerPosition);
            return angle;
        }

        public bool IsFire => Input.GetMouseButton(0);
    }
}