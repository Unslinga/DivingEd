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

namespace Input
{
    public class Input : MonoBehaviour
    {
        #region Fields

        [field: SerializeField]
        public InputEvent InputEvent { get; set; }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods
        private void Awake()
        {

        }
        
        private void Start()
        {
            InputEvent.Raise("Pressed");
        }

        private void Update()
        {
            
        }


        #endregion
        
    } 
}