using System;
using System.Collections;
using Data.SO;
using UnityEngine;
using Util;

namespace Controllers
{
    public class LevelController : MonoBehaviour
    {
        public static event Action<LevelController> LevelEnded = delegate { };
        public static event Action<LevelController> LevelStarted = delegate { };
        public static event Action<LevelController> LevelLoaded = delegate { };

        public void StartLevel()
        {
            LevelStarted.Invoke(this);
        }

        public void InitLevel(LevelData levelData)
        {
            LevelLoaded.Invoke(this);
            StartCoroutine(StartLevelFirst());
        }

        public void EndLevel()
        {
            LevelEnded.Invoke(this);
        }
        private IEnumerator StartLevelFirst()
        {
            yield return new WaitForEndOfFrame();
            GameManager.Instance.StartLevel();
        }
    }
}