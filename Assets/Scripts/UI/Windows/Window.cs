using UnityEngine;

namespace Windows.UI
{
    public abstract class Window : MonoBehaviour
    {
        public virtual void OnLoad()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnShow()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void OnHide()
        {
            gameObject.SetActive(false);
        }
    }
}