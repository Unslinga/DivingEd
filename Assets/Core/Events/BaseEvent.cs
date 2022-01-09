// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    [CreateAssetMenu(menuName = "Events/BaseEvent", order = 1)]
    public class BaseEvent : ScriptableObject
    {
        #region Fields
        private List<EventListener> Listeners = new List<EventListener>();
        #endregion

        #region Properties
        public string Name { get; private set; }
        #endregion

        #region Public Methods
        public void Raise()
        {
            for (int i = Listeners.Count - 1; i >= 0; i--)
            {
                Listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(EventListener listener)
        {
            Listeners.Add(listener);
        }

        public void UnregisterListener(EventListener listener)
        {
            Listeners.Remove(listener);
        }
        #endregion

    }    
}
