using Pool;
using UnityEngine;

namespace GameController
{
    public class TileController : PooledObject
    {
        private BoxController _placedBox;
        public BoxController PlacedBox => _placedBox;

        private int _xIndex;
        private int _yIndex;

        public virtual int XIndex => _xIndex;

        public virtual int YIndex => _yIndex;

        public void Init(int x, int y)
        {
            _xIndex = x;
            _yIndex = y;
        }
        
        public void UpdateState(int x,  int y)
        {
            if (_placedBox != null)
            {
                _placedBox.Move(this, x, y);
            }
        }

        public bool Place(BoxController boxController)
        {
            if (_placedBox == null)
            {
                _placedBox = boxController;
                return true;
            }

            return false;
        }

        public void ClearTile()
        {
            _placedBox = null;
        }
    }
}