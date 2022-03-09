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

        private bool[] pressedInputs;

        #endregion

        #region Public Methods

        public void TestKeys(object data)
        {
            var keyData = (InputData)data;

        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Start()
        {
            pressedInputs = new bool[InputEvents.Count];

            InputEvents["Back"].CreateListener(gameObject, TestKeys);
        }

        void Update()
        {
            foreach (var inputEvent in InputEvents.Items)
            {
                int index = InputEvents.IndexOf(inputEvent);

                bool modifier = Input.GetKeyDown(inputEvent.Modifier) || 
                    Input.GetKey(inputEvent.Modifier) ||
                    Input.GetKeyUp(inputEvent.Modifier);

                if (Input.GetKeyDown(inputEvent.KeyCode))
                {
                    Raise(1);
                }
                if (Input.GetKey(inputEvent.KeyCode) && !pressedInputs[index])
                {
                    Raise(2);
                    pressedInputs[index] = true;
                }
                if (Input.GetKeyUp(inputEvent.KeyCode))
                {
                    Raise(3);
                    pressedInputs[index] = false;
                }

                void Raise(int state)
                {
                    inputEvent.Raise(new InputData { KeyCode = inputEvent.KeyCode, KeyState = state, Modifier = modifier });
                }
            }

            
        }

        #endregion
    }
}