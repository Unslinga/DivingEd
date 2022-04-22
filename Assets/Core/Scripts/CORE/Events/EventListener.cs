// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class EventListener : MonoBehaviour
    {
        [field: SerializeField]
        public BaseEvent Event { get; set; }
        [field: SerializeField]
        public UnityEvent Response { get; set; }
        [field: SerializeField]
        public UnityEvent<object> ParameterResponse { get; set; }
        [field: SerializeField]
        public UnityEvent<string> SpecializedResponse { get; set; }

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

        public void OnEventRaised(string value)
        {
            SpecializedResponse?.Invoke(value);
        }
    } 
}
