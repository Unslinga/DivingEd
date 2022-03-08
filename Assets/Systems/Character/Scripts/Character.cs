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

namespace Character
{
    public class Character : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Properties

        [field: SerializeField]
        public GameObject Camera { get; set; }

        [field: SerializeField]
        public Vector3Reference CameraPosition { get; set; }
      
        public InputEvent KeySpaceInputEvent { get; set; }
        #endregion

        #region Public Methods
        
        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods
        private void Start()
        {
            
        }

        private void Awake()
        {
            //IputEvent.CreateListener(gameObject, KeyDown);
            //KeySpaceInputEvent.CreateListener(gameObject, OnKeyboardInput);

            //ZoomEvent
        }

        private void Update()
        {
            Camera.transform.position = CameraPosition;

        }
        #endregion
        
    } 
}