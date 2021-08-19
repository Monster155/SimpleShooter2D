using UnityEngine;

namespace Game.GameSystem
{
    public class NeDoServer : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private int _teamMembersCount;

        private void Start()
        {
            _gameManager.Init(_teamMembersCount);
            _gameManager.StartGame();
        }
    }
}