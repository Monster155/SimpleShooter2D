using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = System.Object;

namespace Menu
{
    public class InterfaceController : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private string _gameSceneName;

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(StartGameButton_OnClick);
        }

        private void StartGameButton_OnClick()
        {
            SceneManager.LoadScene(_gameSceneName);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(StartGameButton_OnClick);
        }
    }
}