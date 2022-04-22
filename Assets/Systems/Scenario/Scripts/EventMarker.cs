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
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Scenario
{
    public class EventMarker : Marker, INotification
    {
        #region Fields & Properties

        [field: SerializeField]
        public string EventName { get; set; }

        [field: SerializeField]
        public BaseEvent Event { get; set; }

        public PropertyName id => new PropertyName();

        #endregion

        #region Private Methods

        void Setup()
        {
            if (Event == null && EventName != null)
            {
                Event = GameManager.GetNodeByName<BaseEvent>(EventName);
            }
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            Setup();
        }

        void OnValidate()
        {
            Setup();
        }

        #endregion
    }
}