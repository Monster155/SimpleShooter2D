using System.Collections.Generic;
using Game.CharacterScripts;
using Game.CharacterScripts.Factories;
using Game.Map.Spawner;
using UnityEngine;
using Zenject;

namespace Game.GameSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _characterPrefab;
        [SerializeField] private List<CTSpawner> _blueSpawners;
        [SerializeField] private List<TSpawner> _redSpawners;
        [SerializeField] private CharacterFactory _characterFactory;

        private List<Character> _blueCharacters;
        private List<Character> _redCharacters;
        private int _redCharCount, _blueCharCount;
        private int _redScore, _blueScore;
        private int _teamMembersCount;

        public void Init(int teamMembersCount)
        {
            _teamMembersCount = teamMembersCount;
            _blueCharacters = new List<Character>();
            _redCharacters = new List<Character>();
        }

        public void StartGame()
        {
            for (var i = 0; i < _teamMembersCount; i++)
            {
                _blueCharacters.Add(_characterFactory.CreateCharacter(_characterPrefab, false, BlueChar_OnCharacterDead));
                _redCharacters.Add(_characterFactory.CreateCharacter(_characterPrefab, true, RedChar_OnCharacterDead));
            }

            _blueScore = 0;
            _redScore = 0;

            StartRound();
        }

        private void StartRound()
        {
            _blueCharCount = _teamMembersCount;
            _redCharCount = _teamMembersCount;

            for (var i = 0; i < _teamMembersCount; i++)
            {
                _blueCharacters[i] = _characterFactory.ResetCharacter(_blueCharacters[i], _blueSpawners[i]);
                _redCharacters[i] = _characterFactory.ResetCharacter(_redCharacters[i], _redSpawners[i]);
            }
        }

        private void BlueChar_OnCharacterDead()
        {
            _blueCharCount--;
            if (_blueCharCount <= 0)
                StartRound();
        }

        private void RedChar_OnCharacterDead()
        {
            _redCharCount--;
            if (_redCharCount <= 0)
                StartRound();
        }
    }
}