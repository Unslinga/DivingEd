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
    [NodeWidth(272)]
    public abstract class TimelineNode : BaseNode
    {
        #region Fields & Properties

        [field: SerializeField]
        public Frame StartTime { get; set; }

        #endregion

        #region Public Methods

        public abstract void UpdateSettings();

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Awake()
        {
            UpdateSettings();
        }

        void OnValidate()
        {
            UpdateSettings();
        }

        #endregion
    }
}