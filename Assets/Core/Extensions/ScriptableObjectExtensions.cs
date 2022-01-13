// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public static class ScriptableObjectExtensions
    {
        #region Public Static Methods
        /// <summary>
        /// Creates a event listener gameobject that is responsible for relaying the event raised.
        /// </summary>
        /// <param name="baseEvent"></param>
        /// <param name="gameObject"></param>
        /// <param name="unityActions"></param>
        /// <returns></returns>
        public static IEnumerable<EventListener> CreateListener(
            this BaseEvent baseEvent, GameObject gameObject, params UnityAction[] unityActions)
        {
            string info = Environment.StackTrace.Split('\\').Reverse().First().Trim();

            if (baseEvent == null || gameObject == null)
            {
                Debug.LogError($"Event or GameObject [{info}][{baseEvent.Name}] cannot be null!");
            }

            List<EventListener> listeners = new List<EventListener>();
            foreach (var action in unityActions)
            {
                var unityEvent = new UnityEvent();
                unityEvent.AddListener(action);
                
                EventListener listner = CreateGameObjectListener(baseEvent, gameObject);
                listner.Response = unityEvent;

                listeners.Add(listner);
            }

            return listeners;
        }

        public static IEnumerable<EventListener> CreateListener(
            this BaseEvent baseEvent, GameObject gameObject, params UnityAction<object>[] unityActions)
        {
            string info = Environment.StackTrace.Split('\\').Reverse().First().Trim();

            if (baseEvent == null || gameObject == null)
            {
                Debug.LogError($"Event or GameObject [{info}][{baseEvent.Name}] cannot be null!");
            }

            List<EventListener> listeners = new List<EventListener>();
            foreach (var action in unityActions)
            {
                var unityEvent = new UnityEvent<object>();
                unityEvent.AddListener(action);

                EventListener listner = CreateGameObjectListener(baseEvent, gameObject);
                listner.ParameterResponse = unityEvent;

                listeners.Add(listner);
            }

            return listeners;
        }
        #endregion

        #region Private Methods

        private static EventListener CreateGameObjectListener(
            BaseEvent baseEvent, GameObject gameObject)
        {
            var eventObject = new GameObject($"EVENT_{baseEvent.Name}");
            eventObject.transform.parent = gameObject.transform;

            var listner = eventObject.AddComponent<EventListener>();

            listner.Event = baseEvent;
            listner.Event.RegisterListener(listner);
            return listner;
        }

        #endregion
    }
}