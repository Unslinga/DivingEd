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
        public GameObject Body { get; set; }

        [field: SerializeField]
        public GameObject Head { get; set; }

        [field: Header("Player Info")]
        [field: SerializeField]
        public Vector3Reference BodyPosition { get; set; }
        [field: SerializeField]
        public Vector3Reference BodyRotation { get; set; } // Pitch, Yaw, Roll

        [field: SerializeField]
        public Vector3Reference HeadPosition { get; set; }
        [field: SerializeField]
        public Vector3Reference HeadRotation { get; set; }

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
            Body.transform.position = BodyPosition;
        }
        #endregion
        
    } 
}