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
using Cam = UnityEngine.Camera;

namespace Camera
{
    [ExecuteInEditMode]
    public class CameraController : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        [field: ReadOnlyField]
        public Cam Camera { get; set; }

        [field: Header("Camera Settings")]
        [field: SerializeField]
        public FloatReference CameraFOV { get; set; }

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

        void Start()
        {
            Camera = GetComponentInChildren<Cam>();
            CameraFOV.Value = Camera.fieldOfView; // prohibits snapping of values
        }

        void Update()
        {
            Camera.fieldOfView = CameraFOV;
            Camera.transform.position = CameraPosition;
            Camera.transform.rotation = CameraRotation;
        }

        #endregion
    }
}