using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace GameController
{
    [CreateAssetMenu(fileName = "BoxStateManager", menuName = "BoxStateManager", order = 0)]
    public class BoxStateManager : ScriptableObject
    {
        [SerializeField] private List<BoxStateData> _boxStates = new List<BoxStateData>();

        #region Public

        public bool GetNextState(ref BoxStateData currentData)
        {
            int currentIndex = _boxStates.IndexOf(currentData);
            if (currentIndex == _boxStates.Count - 1)
            {
                return false;
            }
            currentData = _boxStates[currentIndex + 1];
            return true;
        }

        #endregion

        #region Unity

        #endregion

        #region Private

        #endregion
    }
}