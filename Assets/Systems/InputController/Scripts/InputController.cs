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
        public InputEvent KeySpaceInputEvent { get; set; }



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
            Debug.Log(keyCode);
        }

        private void Timing(KeyCode keyCode, int i, float time)
        {
            //Determin if its hold or not
            if (time - timer[i] < keyPressDuration)
            {
                KeySpaceInputEvent.Raise(new InputData { KeyCode = KeyCode.Space, Holding = false });
            }
            else
            {
                KeySpaceInputEvent.Raise(new InputData { KeyCode = KeyCode.Space, Holding = false });
            }




            //unlock the pressed key
            //unPressedKeys[i] = keyCode;

            //Raise the event

        }

        //private bool Measure(KeyCode kc) { }
        #endregion

        #region Unity Methods


        private void Start()
        {
            //Initialize the array
            pressedKeys = new KeyCode[unPressedKeys.Length];
            timer = new float[unPressedKeys.Length];

            //for (int i = 0; i < keys.Length; i) InputData a  = new InputData();

        }

        private void Update()
        {
            for (int i = 0; i < unPressedKeys.Length; i++)
            {
                if (Input.GetKeyDown(unPressedKeys[i]))
                {
                    ToRaise(unPressedKeys[i], i);
                }
            }

            for (int i = 0; i < timer.Length; i++)
            {
                if (timer[i] != 0)
                {
                    //check if held
                    
                    if (timer[i] == -1)
                    {
                        Debug.Log("Held");
                        if (Input.GetKeyUp(pressedKeys[i]))
                        {
                            timer[i] = 0;
                            unPressedKeys[i] = pressedKeys[i];
                            pressedKeys[i] = 0;
                        }
                    }


                    if (Time.time - timer[i] > keyPressDuration)
                    {


                        //Press
                        if (Input.GetKeyUp(pressedKeys[i]))
                        {
                            Debug.Log("press");
                            timer[i] = 0;
                            unPressedKeys[i] = pressedKeys[i];
                            pressedKeys[i] = 0;
                        }
                        else
                        //Hold
                        {
                            Debug.Log("hold");
                            timer[i] = -1;
                        }
                            
                    }

                        //   KeySpaceInputEvent.Raise(new InputData {KeyCode =KeyCode.Space, Holding = false });

                    
                }
                #endregion
            }
        }
    }
}