using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameEventListener : MonoBehaviour
    {
        [field: SerializeField]
        public GameEvent Event { get; set; }
        [field: SerializeField]
        public UnityEvent Response { get; set; }

        private void OnEnable()
        {
            Event?.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event?.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response?.Invoke();
        }
    } 
}
