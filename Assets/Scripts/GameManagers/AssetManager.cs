using System.Collections.Generic;
using Data.SO;
using GameController;
using UnityEngine;
using Util;

namespace Controllers
{
    public class AssetManager : Singleton<AssetManager>
    {
        [SerializeField] private LevelController _levelPrefab;

        [SerializeField] private List<LevelData> _levelsData = new List<LevelData>();

        [SerializeField] private BoxController _boxControllerPrefab;

        public BoxController BoxControllerPrefab => _boxControllerPrefab;

        public List<LevelData> LevelsData => _levelsData;

        public LevelController LevelPrefab => _levelPrefab;
    }
}