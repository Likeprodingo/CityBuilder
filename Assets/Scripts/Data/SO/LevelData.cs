using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Data.SO
{
    [CreateAssetMenu(fileName = "Level", menuName = "LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        private void Awake()
        {
            Debug.Log("Awake");
        }

        private void OnEnable()
        {
            Debug.Log("Enable");
        }

        private void OnDisable()
        {
            Debug.Log("DIsable");
        }

        private void OnDestroy()
        {
            Debug.Log("Destroy");
        }
    }
}