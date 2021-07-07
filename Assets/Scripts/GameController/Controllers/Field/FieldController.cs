using System.Collections.Generic;
using Windows.UI;
using Controllers;
using DefaultNamespace;
using Pool;
using Types;
using UnityEngine;

namespace GameController
{
    public class FieldController : MonoBehaviour
    {
        [SerializeField] private List<TileController> _tiles = new List<TileController>();
        [SerializeField] private FieldData _dataSo;

        #region Public
        
        #endregion
        
        #region Unity

        private void Awake()
        {
           InitField();
        }

        private void OnEnable()
        {
            PlayerSwipeController.Swipped += PlayerSwipeControllerOnSwipped;
        }
        
        private void OnDisable()
        {
            PlayerSwipeController.Swipped -= PlayerSwipeControllerOnSwipped;
        }

        #endregion

        #region Action
        
        private void PlayerSwipeControllerOnSwipped(SwipeType obj)
        {
            Debug.LogError("Swipe " + obj);
            switch (obj)
            {
                case SwipeType.LEFT:
                    SwipeLeft();
                    break;
                case SwipeType.DOWN:
                    SwipeDown();
                    break;
                case SwipeType.RIGHT:
                    SwipeRight();
                    break;
                case SwipeType.UP:
                    SwipeUp();
                    break;
            }
        }

        #endregion

        #region Private

        private void InitField()
        {
         
            if (_dataSo.Height * _dataSo.Width <= _tiles.Count)
            {
                var field = new TileController[_dataSo.Height,_dataSo.Width];
                int index = 0;
                for (int i = 0; i < _dataSo.Height; i++)
                {
                    for (int j = 0; j < _dataSo.Width; j++)
                    {
                        field[i,j] = _tiles[index++];
                        field[i,j].Init(j,i);
                    }
                }
                _dataSo.Field = field;
            }
        }

        private void SwipeLeft()
        {
            for (int i = 0; i < _dataSo.Height; i++)
            {
                for (int j = 1; j < _dataSo.Width; j++)
                {
                    var tile = _dataSo.Field[i,j];
                    tile.UpdateState(-1, 0);
                }
            }
        }
        
        private void SwipeRight()
        {
            for (int i = 0; i < _dataSo.Height; i++)
            {
                for (int j = _dataSo.Width - 2; j >= 0; j--)
                {
                    var tile = _dataSo.Field[i,j];
                    tile.UpdateState(1, 0);
                }
            }
        }

        private void SwipeDown()
        {
            for (int j = 0; j < _dataSo.Width; j++)
            {
                for (int i = _dataSo.Height - 2; i >= 0; i--)
                {
                    var tile = _dataSo.Field[i,j];
                    tile.UpdateState(0, 1);
                }
            }
        }
        
        private void SwipeUp()
        {
            for (int j = 0; j < _dataSo.Width; j++)
            {
                for (int i = 1; i < _dataSo.Height; i++)
                {
                    var tile = _dataSo.Field[i,j];
                    tile.UpdateState(0, -1);
                }
            }
        }
    }

    #endregion
}