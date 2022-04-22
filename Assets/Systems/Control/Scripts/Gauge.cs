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

namespace Control.Gauge
{
    public class Gauge : Control
    {
        #region Fields & Properties

        [field: SerializeField]
        public override BaseNode Node { get; set; }

        public GaugeNode GaugeNode => (GaugeNode)Node;

        [field: SerializeField]
        public GameObject Pointer { get; set; }

        [field: Header("Gauge Settings")]

        [field: SerializeField]
        public float OffsetAngle { get; set; }

        [field: SerializeField]
        public float ScaleAngle { get; set; }

        [field: SerializeField]
        private float FlowAmount { get; set; } = 0.1f;

        public float PointerAngle
        {
            get
            {
                return (float)(OffsetAngle + (GaugeNode.Value * ScaleAngle));
            }
        }

        private float elapsed;
        private Quaternion startValue;
        private Quaternion endValue;
        private Quaternion needleAngle;

        #endregion

        #region Public Methods

        public void UpdateAngle()
        {
            if (GaugeNode == null) return;

            LerpValues();
            Pointer.transform.rotation = needleAngle;
        }


        private void LerpNeedle()
        {
            if (elapsed < FlowAmount)
            {
                needleAngle = Quaternion.Lerp(startValue, endValue, elapsed / FlowAmount);

                elapsed += Time.fixedDeltaTime;
                return;
            }

            needleAngle = endValue;
            elapsed = 0;
        }

        private void LerpValues()
        {
            startValue = Pointer.transform.rotation;
            endValue = Quaternion.Euler(0, 0, PointerAngle);
        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void FixedUpdate()
        {
            if (GaugeNode == null) return;

            UpdateAngle();

            LerpNeedle();
        }

        #endregion
    }
}