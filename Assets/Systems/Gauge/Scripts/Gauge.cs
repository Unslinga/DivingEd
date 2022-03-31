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

namespace Gauge
{
    public class Gauge : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public GaugeNode GaugeNode { get; set; }

        [field: SerializeField]
        public GameObject Pointer { get; set; }

        [field: Header("Gauge Settings")]

        [field: SerializeField]
        public float OffsetAngle { get; set; }

        [field: SerializeField]
        public float ScaleAngle { get; set; }

        public float PointerAngle
        {
            get
            {
                return (float)(OffsetAngle + (GaugeNode.Value * ScaleAngle));
            }
        }

        #endregion

        #region Public Methods

        public void UpdateAngle()
        {
            if (GaugeNode == null) return;

            Pointer.transform.rotation = Quaternion.Euler(0, 0, PointerAngle);
        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        private void Update()
        {
            UpdateAngle();
        }

        #endregion
    } 
}