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
        private float keyPressDuration;

        [field: SerializeField]
        private KeyCode[] unPressedKeys;
        private KeyCode[] pressedKeys;
        private float[] timer;


        [field: SerializeField]
        public InputEvent KeyInputEvent { get; set; }



        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void ToRaise(KeyCode keyCode, int i)
        {
            //Lock the pressed key
            unPressedKeys[i] = 0;
            pressedKeys[i] = keyCode;
            timer[i] = Time.time;
            Debug.Log(keyCode + "down");
        }

        #endregion

        #region Unity Methods


        private void Start()
        {
            //Initialize the array
            pressedKeys = new KeyCode[unPressedKeys.Length];
            timer = new float[unPressedKeys.Length];
        }

        private void Update()
        {
            //Checking if any key of the reserved keys is pressed
            for (int i = 0; i < unPressedKeys.Length; i++)
            {
                if (Input.GetKeyDown(unPressedKeys[i]))
                {
                    //Removing the key from the reserved keys and start timing
                    ToRaise(unPressedKeys[i], i);
                }
            }

            //Checking if a pressed key is released
            for (int i = 0; i < pressedKeys.Length; i++)
            {
                if (Input.GetKeyUp(pressedKeys[i]))
                {
                    //Determin if its a press, or hold
                    if (timer[i] > -1)
                    {
                        Debug.Log("press");
                        Debug.Log(pressedKeys[i] + "up");
                        //KeyInputEvent.Raise(new InputData { KeyCode = pressedKeys[i], Holding = false });
                        unPressedKeys[i] = pressedKeys[i];
                        pressedKeys[i] = 0;
                        timer[i] = 0;
                        
                    } else
                    {
                        Debug.Log(pressedKeys[i] + "up");
                        unPressedKeys[i] = pressedKeys[i];
                        pressedKeys[i] = 0;
                        timer[i] = 0;
                    }

                    
                }
            }


            for (int i = 0; i < timer.Length; i++)
            {
                if (timer[i] > 0)
                {               
                    if (Time.time - timer[i] > keyPressDuration)
                    {
                        //Hold
                        {
                            Debug.Log("holding");
                            //KeyInputEvent.Raise(new InputData { KeyCode = pressedKeys[i], Holding = true });
                            timer[i] = -1;
                        }

                    }
                }
                #endregion
            }
        }
    }
}