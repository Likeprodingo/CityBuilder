using System;
using System.Linq;
using Windows;
using Windows.UI;
using UnityEngine;
using Util;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
        public static event Action<Window> OnShown = delegate { };
        
        [SerializeField]
        private GameObject _windowsContainer = null;
        
        private Window _current = null;
        private Window[] _windows = null;
        
        public Window CurrentWindow => _current;
        
        private void Awake()
        {
            _windows = _windowsContainer.GetComponentsInChildren<Window>(true);
            _windows.Do(wind => wind.OnLoad());
        }

        public  void ShowWindow<T>()
            where T : Window
        {
            var window = GetWindow<T>();

            if (!ReferenceEquals(_current, null))
            {
                _current.OnHide();
            }

            window.OnShow();

            OnShown.Invoke(window);

           _current = window;
        }

        private  Window GetWindow<T>()
            where T : Window
        {
            var window = _windows.FirstOrDefault(w => w is T);

            if (!window)
            {
                Debug.LogException(new Exception($"{typeof(T)} not found!"));
            }

            return window;
        }
        
    }
}