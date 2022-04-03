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

namespace Control
{
    public class Control : MonoBehaviour
    {
        #region Fields & Properties

        public virtual BaseNode Node { get; set; }
        private ControlLabel label;

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        protected void SetLabel()
        {
            label = GetComponentInChildren<ControlLabel>();

            if (label == null) return;
            label.Label = Node?.name;
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            SetLabel();
        }

        void OnValidate()
        {
            SetLabel();
        }

        #endregion
    }
}