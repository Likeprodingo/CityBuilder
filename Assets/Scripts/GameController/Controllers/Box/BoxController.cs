using System;
using DefaultNamespace;
using DG.Tweening;
using Pool;
using Types;
using UnityEngine;
using UnityEngine.UI;

namespace GameController
{
    public class BoxController : PooledObject
    {
        [SerializeField] private FieldData _fieldData;
        [SerializeField] private BoxStateData _boxStateData;
        [SerializeField] private BoxStateManager _boxStateManager;
        [SerializeField] private float _moveAnimationTime;

        private BoxViewController _boxViewController;
        private BoxStateData BoxStateData => _boxStateData;

        #region Public

        public void Move(TileController tileController, int xDelta, int yDelta)
        {
            Sequence moveSequence = DOTween.Sequence();
            int xNext = tileController.XIndex + xDelta;
            int yNext = tileController.YIndex + yDelta;
            if (_fieldData.IsInRange( xNext, yNext))
            {
                var nextTile = _fieldData.Field[yNext,xNext];
                var nextTilePlacedBox = nextTile.PlacedBox;
                if (nextTilePlacedBox != null)
                {
                    if (nextTilePlacedBox.BoxStateData == _boxStateData)
                    {
                        moveSequence.Append(transform.DOMove(nextTile.transform.position,
                            _moveAnimationTime)).OnComplete(() =>
                        {
                            nextTilePlacedBox.Upgrade();
                            Free();
                        });
                        tileController.ClearTile();
                    }
                    else
                    {
                        tileController.Place(this);
                    }
                }
                else
                {
                    tileController.ClearTile();
                    moveSequence.Append(transform.DOMove(nextTile.transform.position,
                        _moveAnimationTime));
                    Move(_fieldData.Field[yNext,xNext], xDelta, yDelta);
                }
            }
            else
            {
                tileController.Place(this);
            }
        }

        #endregion

        #region Unity

        private void Awake()
        {
            _boxViewController = GetComponent<BoxViewController>();
        }

        #endregion
        
        #region Privat

        private void Upgrade()
        {
            if (_boxStateManager.GetNextState(ref _boxStateData))
            {
                Debug.LogError("Upgrade");
                _boxViewController.UpdateView(_boxStateData);
            }
        }
        
        #endregion
    }
}