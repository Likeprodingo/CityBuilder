using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace GameController
{
    public class BoxViewController : MonoBehaviour
    {
        private Image _imageComponent;
        
        #region Public

        public void UpdateView(BoxStateData boxStateData)
        {
          
        }
        
        #endregion

        #region Unity
        
        private void Awake()
        {
            _imageComponent = GetComponent<Image>();
        }

        #endregion

        #region Private

        #endregion
    }
}