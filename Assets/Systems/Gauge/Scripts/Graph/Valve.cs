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
        
        bool holding = false;
        public Vector3Reference MousePosition { get; set; }
        public Collider ValveBody { get; set; }


        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        public void ToggleMouse (object data)
        {
            //Debug.Log(data);
            var button = (MouseInputData) data;
            //Debug.Log(button.State);

            if (button.State == 0)
            {
                RaycastHit hit;

                Ray ray = Camera.main.ScreenPointToRay(MousePosition);

                if (Physics.Raycast(ray, out hit, 1000)) /// 1000 = distance
                {
                    if (hit.collider == ValveBody)
                    {
                        Debug.Log("Hit");
                        holding = true;
                    }
                }
            }

            if (button.State == 2)
                holding = false;

        }
        
        #endregion

        #region Unity Methods

        void Start()
        {
            Inputs["LeftClick"].CreateListener(gameObject, ToggleMouse);
        }

        void Update()
        {
        
        }

        #endregion
    }
}