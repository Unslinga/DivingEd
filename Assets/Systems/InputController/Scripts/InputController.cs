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
        #region Fields & Properties

        [field: SerializeField]
        public InputEventNamedSet InputEvents { get; private set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Update()
        {
            foreach (var inputEvent in InputEvents.Items)
            {
                if (Input.GetKeyDown(inputEvent.KeyCode))
                {
                    inputEvent.Raise(new InputData { KeyState = 1 });
                }
                if (Input.GetKey(inputEvent.KeyCode))
                {
                    inputEvent.Raise(new InputData { KeyState = 2 });
                }
                if (Input.GetKeyUp(inputEvent.KeyCode))
                {
                    inputEvent.Raise(new InputData { KeyState = 3 });
                }
            }
        }

        #endregion
    }
}