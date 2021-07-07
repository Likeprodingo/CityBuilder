using System;
using UnityEngine;
using Util;

namespace Controllers
{
    public class GameManager : Singleton<GameManager>
    {
        private readonly string CURRENT_LEVEL_INDEX = "CurrentLevelIndex";
        private LevelController _currentLevel;

        private int _currentLevelIndex;
        
        public void EndLevel()
        {
            PlayerPrefs.SetInt(CURRENT_LEVEL_INDEX, ++_currentLevelIndex);
            _currentLevel.EndLevel();
        }

        public void StartLevel()
        {
            _currentLevel.StartLevel();
        }

        public void LoadLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
            }

            _currentLevelIndex = PlayerPrefs.GetInt(CURRENT_LEVEL_INDEX, 0);
            _currentLevel = Instantiate(AssetManager.Instance.LevelPrefab);
            _currentLevel.InitLevel(AssetManager.Instance.LevelsData[_currentLevelIndex]);
        }
    }
}