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
    [Serializable]
    public abstract class Control : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public virtual ControlNode Node { get; set; }

        [field: SerializeField]
        [field: ReadOnlyField]
        public virtual double Value { get; set; }


        [field: SerializeField]
        [field: ReadOnlyField]
        public virtual double ControlValue { get; set; }

        private ControlLabel label;

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        protected void SetLabel()
        {
            label = GetComponentInChildren<ControlLabel>();

            if (label == null) return;
            label.Label = Node != null ? Node.name : "xx";
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            this.CheckNull(Node, true);

            Node.Control = this;

            SetLabel();
        }

        void OnValidate()
        {
            SetLabel();
        }

        #endregion
    }
}