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
    public class BodyAngle : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public Vector3Int Axis { get; set; }

        #endregion

        #region Unity Methods

        void Start()
        {
            var random = UnityEngine.Random.Range(0, 0.5f) * 360;

            transform.rotation = Quaternion.Euler(random * Axis.x, random * Axis.y, random * Axis.z);
        }

        #endregion
    }
}