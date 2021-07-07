using System;
using System.Collections;
using Controllers;
using Pool;
using UI;
using UnityEngine;
using Object = System.Object;

namespace GameManagers
{
    public class StarterManager : MonoBehaviour
    {
        private void Start()
        {
            AssetManager.Instance.Init();
            ObjectPool.Instance.Init();
            UIManager.Instance.Init();
            GameManager.Instance.Init();
            GameManager.Instance.LoadLevel();
        }
    }
}