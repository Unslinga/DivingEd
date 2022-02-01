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

namespace InputController
{
    public class InputController : MonoBehaviour
    {
        #region Fields


        #endregion

        #region Properties
        [field: SerializeField]
        public InputEvent KeyboardInputEvent { get; set; }


        #endregion

        #region Public Methods
        
        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods
        
        
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KeyboardInputEvent.Raise(new InputData {KeyCode =KeyCode.Space, Holding = false });
            }

            if (Input.GetKey(KeyCode.Space))
            {
                KeyboardInputEvent.Raise(new InputData { KeyCode = KeyCode.Space, Holding = true });
            }
        }


        #endregion
        
    } 
}