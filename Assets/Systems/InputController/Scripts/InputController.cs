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
using System.Linq;
using UnityEngine;

namespace InputController
{
    public class InputController : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public InputEventSet InputEvents { get; private set; }

        [field: SerializeField]
        public Vector2Variable MousePosition { get; set; }

        private Vector2 lastPosition;
        [field: SerializeField]
        public Vector2Variable MouseDelta { get; set; }

        private bool[] pressedInputs;

        #endregion

        #region Public Methods

        public void TestKeys(string data)
        {
            var keyData = data.Parse<KeyboardInputData>();
            Debug.Log($"Key: [{keyData.KeyCode}], s: [{keyData.State}], m: [{keyData.Modifier}]");
        }

        public void TestButtons(string data)
        {
            var ButtonData = data.Parse<MouseInputData>();
            Debug.Log($"Button: [{ButtonData.Button}], s: [{ButtonData.State}]");
        }

        #endregion

        #region Private Methods

        private void HandleKeyboardInputs()
        {
            foreach (KeyboardInputEvent inputEvent in InputEvents.Items.Where(i => i is KeyboardInputEvent))
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
                    inputEvent.Raise((inputEvent.KeyCode, state, modifier).Compose());
                }
            }
        }

        private void HandleMouseInputs()
        {
            foreach (MouseInputEvent inputEvent in InputEvents.Items.Where(i => i is MouseInputEvent))
            {
                int index = InputEvents.IndexOf(inputEvent);

                if (Input.GetMouseButtonDown(inputEvent.Button))
                {
                    Raise(0);
                }
                if (Input.GetMouseButton(inputEvent.Button) && !pressedInputs[index])
                {
                    Raise(1);
                    pressedInputs[index] = true;
                }
                if (Input.GetMouseButtonUp(inputEvent.Button))
                {
                    Raise(2);
                    pressedInputs[index] = false;
                }

                void Raise(byte state)
                {
                    inputEvent.Raise((inputEvent.Button, state).Compose());
                }
            }
        }

        private void HandleMouseMovement()
        {
            MousePosition.Value = Input.mousePosition;
            MouseDelta.Value = MousePosition - lastPosition;
            lastPosition = MousePosition;
        }

        #endregion

        #region Unity Methods

        void Start()
        {
            pressedInputs = new bool[InputEvents.Count];

            MousePosition.Value = Input.mousePosition;

            //InputEvents["Back"].CreateListener(gameObject, TestKeys);
            //InputEvents["RightClick"].CreateListener(gameObject, TestButtons);
        }

        void Update()
        {
            HandleKeyboardInputs();
            HandleMouseInputs();
            HandleMouseMovement();
        }

        #endregion
    }
}