using System;
using Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Windows.UI
{
    public class PlayerSwipeController : MonoBehaviour, IDragHandler
    {
        public static event Action<SwipeType> Swipped = delegate { };

        [SerializeField] private float _minDrag = 3;

        public void OnDrag(PointerEventData eventData)
        {
            var xDelta = Mathf.Abs(eventData.delta.x);
            var yDelta = Mathf.Abs(eventData.delta.y);
            Debug.Log(eventData.delta);
            if (xDelta > yDelta)
            {
                if (xDelta > _minDrag)
                {
                    if (eventData.delta.x > 0)
                    {
                        Swipped.Invoke(SwipeType.RIGHT);
                    }
                    else
                    {
                        Swipped.Invoke(SwipeType.LEFT);
                    }
                }
            }
            else
            {
                if (yDelta > _minDrag)
                {
                    if (eventData.delta.y > 0)
                    {
                        Swipped.Invoke(SwipeType.UP);
                    }
                    else
                    {
                        Swipped.Invoke(SwipeType.DOWN);
                    }
                }
            }
        }
    }
}