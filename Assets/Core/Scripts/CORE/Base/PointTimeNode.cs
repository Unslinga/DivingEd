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

namespace Scenario
{
    public class PointTimeNode : TimelineNode
    {
        #region Fields & Properties

        [field: Header("Event Settings")]

        [field: SerializeField]
        public string EventName { get; set; }

        [field: SerializeField]
        public BaseEvent Event { get; set; }

        [field: SerializeField]
        public string Action { get; set; }

        #endregion

        #region Public Methods

        public override string GetValues()
        {
            return (name, EventName, Action).Compose();
        }

        public override void SetValues(string data)
        {
            (string name, string eventname, string action) = data.Parse<string, string, string>();

            this.name = name;
            EventName = eventname;
            Action = action;
        }

        public override void UpdateSettings()
        {
            Event = GameManager.GetNodeByName<BaseEvent>(EventName);
        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Start()
        {

        }

        void Update()
        {

        }

        #endregion
    }
}