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
        public InputNamedSet InputEvents { get; private set; }

        private bool[] pressedInputs;

        #endregion

        #region Public Methods

        public void TestKeys(object data)
        {
            var keyData = (InputData)data;
            Debug.Log($"Key: [{keyData.KeyCode}], s: [{keyData.KeyState}], m: [{keyData.Modifier}]");
        }

        #endregion

        #region Private Methods

        private void HandleKeyboardInputs()
        {
            foreach (KeyboardInputEvent inputEvent in InputEvents.Items)
            {
                int index = InputEvents.IndexOf(inputEvent);

                bool modifier = Input.GetKey(inputEvent.Modifier) || Input.GetKeyUp(inputEvent.Modifier);

                if (Input.GetKeyDown(inputEvent.KeyCode))
                {
                    Raise(0);
                }
                if (Input.GetKey(inputEvent.KeyCode) && !pressedInputs[index])
                {
                    Raise(1);
                    pressedInputs[index] = true;
                }
                if (Input.GetKeyUp(inputEvent.KeyCode))
                {
                    Raise(2);
                    pressedInputs[index] = false;
                }

                void Raise(byte state)
                {
                    inputEvent.Raise(new InputData { KeyCode = inputEvent.KeyCode, KeyState = state, Modifier = modifier });
                }
            }
        }

        private void HandleMouseInputs()
        {

        }

        #endregion

        #region Unity Methods

        void Start()
        {
            pressedInputs = new bool[InputEvents.Count];

            InputEvents["Back"].CreateListener(gameObject, TestKeys);
        }

        void Update()
        {
            HandleKeyboardInputs();
            HandleMouseInputs();
        }

        #endregion
    }
}