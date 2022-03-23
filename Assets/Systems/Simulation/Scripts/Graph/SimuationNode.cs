// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using Simulation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Core
{
    [NodeWidth(272)]
    public abstract class SimuationNode : BaseNode
    {
        #region Fields & Properties


        public double Value { get; protected set; }
        public GameObject GameObject { get; set; }

        #endregion

        #region Public Methods



        public override object GetValue(NodePort port)
        {
            return Value;
        }

        public abstract void UpdateValue();

        #endregion

        #region Private Methods

        private void Validate()
        {
            
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            Validate();
        }

        void OnValidate()
        {
            Validate();
        }

        void Reset()
        {
            Validate();
        }

        #endregion
    }
}