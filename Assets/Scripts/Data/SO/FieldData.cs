using System;
using System.Collections.Generic;
using GameController;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Field", menuName = "InGameData", order = 0)]

    public class FieldData : ScriptableObject
    {
        [SerializeField] private int _height = 3;
        [SerializeField] private int _width = 3;

        public int Height => _height;
        public int Width => _width;

        private TileController[,] _field;

        public TileController[,] Field
        {
            get => _field;
            set => _field = value;
        }

        public bool IsInRange(int x, int y)
        {
            if (x < _width && x >= 0 && y >= 0 && y < _height )
            {
                return true;
            }

            return false;
        }
    }
}