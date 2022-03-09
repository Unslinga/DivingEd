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

namespace Camera
{
    [ExecuteInEditMode]
    public class CameraController : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public Vector3Reference CameraPosition { get; set; }

        [field: SerializeField]
        public QuaternionReference CameraRotation { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Update()
        {
            transform.position = CameraPosition;
            transform.rotation = CameraRotation;
        }

        #endregion
    }
}