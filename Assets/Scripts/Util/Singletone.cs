using System;
using UnityEngine;

namespace Util
{
    public abstract class Singleton<T> : MonoBehaviour
        where T : Component
    {
        private static T _instance = null;
        
        public static T Instance
        {
            get
            {
                if (ReferenceEquals(_instance,null))
                {
                    _instance = FindObjectOfType<T>();
                }
                return _instance;
            }
        }
        
        public virtual void Init()
        {
           
        }
        
        public virtual void DeInit()
        {
        }
    }
}