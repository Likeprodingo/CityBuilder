using System;
using System.Collections;
using Controllers;
using DefaultNamespace;
using Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameController
{
    
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private FieldData _dataSo;
        [SerializeField] private int _startNumber;
        [SerializeField] private float _spawnDelay;
        
        #region Public

        public void SpawnBox()
        {
            int x = Random.Range(0, _dataSo.Width);
            int y = Random.Range(0, _dataSo.Height);
            var box = ObjectPool.Instance.Get<BoxController>(AssetManager.Instance.BoxControllerPrefab, transform);
            while (!_dataSo.Field[y,x].Place(box))
            {
                x = Random.Range(0, _dataSo.Width);
                y = Random.Range(0, _dataSo.Height);
            }
            box.transform.position = _dataSo.Field[y,x].transform.position;
        }
        
        #endregion

        #region Unity

        private void OnEnable()
        {
           LevelController.LevelStarted += LevelControllerOnLevelStarted;
        }

        
        private void OnDisable()
        {
            LevelController.LevelStarted -= LevelControllerOnLevelStarted;
        }
        
        
        #endregion

        #region Actions

        private void LevelControllerOnLevelStarted(LevelController obj)
        {
            StartCoroutine(SpawnPack(_startNumber));
        }

        #endregion

        #region Private

        private IEnumerator SpawnPack(int num)
        {
            var waiter = new WaitForSeconds(_spawnDelay);
            for (int i = 0; i < num; i++)
            {
                SpawnBox();
                yield return waiter;
            }
        }
        
        #endregion
    }
}