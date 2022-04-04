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

namespace Control.Valve
{
    public class Valve : Control
    {
        #region Fields & Properties
        
        [field: SerializeField]
        public override BaseNode Node { get; set; }

        public ValveNode ValveNode => (ValveNode)Node;

        [field: SerializeField]
        public Collider ValveBody { get; set; }

        [field: Header("Mouse Settings")]

        [field: SerializeField]
        public MouseInputEvent MouseClick { get; set; }
        private bool activeThis = false;

        [field: SerializeField]
        public Vector2Reference MousePosition { get; set; }

        [field: SerializeField]
        public BoolReference MouseActive { get; set; }

        [field: Header("Angle Settings")]

        [field: SerializeField]
        public int OffsetAngle { get; set; }

        [field: SerializeField]
        public int MaximumAngle { get; set; }

        [field: SerializeField]
        public bool ReverseAngle { get; set; }

        [field: SerializeField]
        public bool BallValve { get; set; }

        [field: SerializeField]
        [field: Range(0,1)]
        public float CutoffValue { get; set; } = 0f;

        [field: Header("Angle Info")]

        [field: SerializeField]
        [field: ReadOnlyField]
        public float RelativeAngle { get; private set; }

        [field: SerializeField]
        [field: ReadOnlyField]
        public float Angle { get; private set; }

        [field: Space(8)]
        [field: SerializeField]
        [field: ReadOnlyField]
        public double Value { get; set; }

        private float deltaAngle;
        private float lastAngle;

        private Vector3 ValvePosition => Camera.main.WorldToScreenPoint(transform.position);
        private float ValvePositionZ => ValvePosition.z;

        private Vector3 ValveHitRelative { get; set; }

        #endregion

        #region Public Methods

        public void MouseHitActivation(object data)
        {
            var key = (MouseInputData)data;
            if (key.State == 0)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main
                    .ScreenPointToRay(MousePosition.Value), out hit, 1000))
                {
                    if (hit.collider == ValveBody)
                    {
                        var hitRelative = Camera.main.WorldToScreenPoint(hit.point);
                        ValveHitRelative = new Vector3(hitRelative.x, hitRelative.y, ValvePositionZ);

                        CalculateRelativeAngle();

                        lastAngle = RelativeAngle;
                        deltaAngle = 0;

                        activeThis = true;
                    }
                }

            }
            
            if (key.State == 2)
            {
                activeThis = false;
            }
        }

        #endregion

        #region Private Methods

        private void AngleValveBody()
        {
            ValveBody.transform.parent.rotation = Quaternion.Euler(0, 0, Angle);
        }

        private void CalculateAngle()
        {
            if (!activeThis) return;

            deltaAngle = RelativeAngle - lastAngle;
            lastAngle = RelativeAngle;

            if (deltaAngle > 180 || deltaAngle < -180) deltaAngle = 0;

            Angle += deltaAngle;

            Angle = Mathf.Clamp(Angle, 0 + OffsetAngle, MaximumAngle + OffsetAngle);
        }

        private void CalculateRelativeAngle()
        {
            if (!activeThis) return;

            var xRelative = Mathf.Sign(MousePosition.Value.x - ValvePosition.x);

            RelativeAngle = Vector2.Angle((ValvePosition + Vector3.up) - ValvePosition, 
                (Vector3)MousePosition.Value - ValvePosition)
                * xRelative + 180;
        }

        private void CalculateValue()
        {
            var value = (Angle - OffsetAngle) / MaximumAngle;

            Value = ReverseAngle ? 1 - value : value;

            var nodeValue = Value;

            if (BallValve)
            {
                nodeValue = Value > CutoffValue ? 1 : 0;
            }

            ValveNode.Value = nodeValue;
        }

        private void FetchAngleFromValue()
        {
            if (BallValve)
            {
                return;
            }

            Value = ValveNode.Value;

            var value = ReverseAngle ? 1 - Value : Value;

            Angle = (float)(value * MaximumAngle + OffsetAngle);
        }

        #endregion

        #region Unity Methods

        void FixedUpdate()
        {
            if (ValveNode == null) return;

            MouseActive.Value = !activeThis;

            FetchAngleFromValue();
            CalculateRelativeAngle();
            CalculateAngle();
            AngleValveBody();
            CalculateValue();
        }

        void OnDrawGizmos()
        {
            if (!activeThis) return;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(ValvePosition), 0.005f);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(ValveHitRelative), 0.005f);

            var pos = new Vector3(MousePosition.Value.x, MousePosition.Value.y, ValvePositionZ);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(pos), 0.005f);
        }

        void Awake()
        {
            this.CheckNull(ValveNode, false);

            OffsetAngle = Mathf.Clamp(OffsetAngle, OffsetAngle, 0);
            MaximumAngle = Mathf.Clamp(MaximumAngle, 0, MaximumAngle);
            CutoffValue = Mathf.Clamp(CutoffValue, 0, MaximumAngle);

            MouseClick?.CreateListener(gameObject, MouseHitActivation);
        }

        #endregion
    }
}