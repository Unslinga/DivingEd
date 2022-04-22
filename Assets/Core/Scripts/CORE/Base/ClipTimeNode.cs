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
    public class ClipTimeNode : TimelineNode
    {
        #region Fields & Properties

        [field: SerializeField]
        public Frame Duration { get; set; }

        #endregion

        #region Public Methods

        public override string GetValues()
        {
            return (name, Duration.F).Compose();
        }

        public override void SetValues(string data)
        {
            (string name, int duration) = data.Parse<string, int>();

            this.name = name;
            Duration = new Frame(duration);
        }

        public override void UpdateSettings()
        {

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