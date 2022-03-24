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

namespace Valve
{
    public class Valve : MonoBehaviour
    {
        #region Fields & Properties
        [field:SerializeField]
        public InputEventSet Inputs { get; set; }
        //[field: SerializeField]
        //GameObject gameObject;
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        public void ToggleMouseDrag(object data)
        {
            Debug.Log("sadasdas");
            
        }
        #endregion

        #region Unity Methods

        void Start()
        {
            Inputs["LeftClick"].CreateListener(gameObject, ToggleMouseDrag);
        }

        void Update()
        {
        
        }

        #endregion
    }
}