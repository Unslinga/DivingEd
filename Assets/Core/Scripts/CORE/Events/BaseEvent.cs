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
using System.Linq;
using UnityEngine.Events;
using UnityEditor;

namespace Core
{
    public abstract class BaseEvent : ScriptableObject
    {
        #region Fields

        private List<EventListener> Listeners = new List<EventListener>();

        #endregion

        #region Properties

        [field: ReadOnlyField]
        [field: SerializeField]
        public string Name { get; protected set; }

        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a event listener gameobject that is responsible for relaying the event raised.
        /// </summary>
        /// <param name="baseEvent"></param>
        /// <param name="gameObject"></param>
        /// <param name="unityActions"></param>
        /// <returns></returns>
        public IEnumerable<EventListener> CreateListener(
            GameObject gameObject, params UnityAction[] unityActions)
        {
            string info = Environment.StackTrace.Split('\\').Reverse().First().Trim();

            if (gameObject == null)
            {
                Debug.LogError($"GameObject [{info}][{Name}] cannot be null!");
            }

            List<EventListener> listeners = new List<EventListener>();
            foreach (var action in unityActions)
            {
                var unityEvent = new UnityEvent();
                unityEvent.AddListener(action);

                EventListener listner = CreateGameObjectListener(gameObject);
                listner.Response = unityEvent;

                listeners.Add(listner);
            }

            return listeners;
        }

        public IEnumerable<EventListener> CreateListener(
            GameObject gameObject, params UnityAction<object>[] unityActions)
        {
            string info = Environment.StackTrace.Split('\\').Reverse().First().Trim();

            if (gameObject == null)
            {
                Debug.LogError($"GameObject [{info}][{Name}] cannot be null!");
            }

            List<EventListener> listeners = new List<EventListener>();
            foreach (var action in unityActions)
            {
                var unityEvent = new UnityEvent<object>();
                unityEvent.AddListener(action);

                EventListener listner = CreateGameObjectListener(gameObject);
                listner.ParameterResponse = unityEvent;

                listeners.Add(listner);
            }

            return listeners;
        }

        public void Raise()
        {
            for (int i = Listeners.Count - 1; i >= 0; i--)
            {
                Listeners[i].OnEventRaised();
            }
        }

        public void Raise<T>(T value)
        {
            for (int i = Listeners.Count -1; i >= 0; i--)
            {
                Listeners[i].OnEventRaised(value);
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

        #region Private Methods

        protected EventListener CreateGameObjectListener(GameObject gameObject)
        {
            var eventObject = new GameObject($"EVENT_{Name}");
            eventObject.transform.parent = gameObject.transform;

            var listner = eventObject.AddComponent<EventListener>();

            listner.Event = this;
            listner.Event.RegisterListener(listner);
            return listner;
        }

        protected void Validate()
        {
            Name = name;
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            Validate();
        }

        void OnEnable()
        {
            Validate();
        }

        void OnValidate()
        {
            Validate();
        }

        #endregion
    }
}
