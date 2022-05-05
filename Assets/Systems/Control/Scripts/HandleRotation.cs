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

namespace Control
{
    [RequireComponent(typeof(Control))]
    public class HandleRotation : MonoBehaviour
    {
        #region Fields & Properties

        private Control control;
        private BaseNode node;

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
        public bool Reverse { get; set; }

        [field: Header("Angle Info")]

        [field: SerializeField]
        [field: ReadOnlyField]
        public float RelativeAngle { get; private set; }

        [field: SerializeField]
        [field: ReadOnlyField]
        public float Angle { get; private set; }

        private float deltaAngle;
        private float lastAngle;

        private Vector3 ValvePosition => Camera.main.WorldToScreenPoint(transform.position);
        private float ValvePositionZ => ValvePosition.z;

        private Vector3 ValveHitRelative { get; set; }

        #endregion

        #region Public Methods

        public void MouseHitActivation(string data)
        {
            (int button, byte state) = data.Parse<int, byte>();
            if (state == 0)
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

            if (state == 2)
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
            Angle = (float)(control.ControlValue * MaximumAngle + OffsetAngle);
        }

        private void CalculateControlAngle()
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

            control.ControlValue = Reverse ? 1 - value : value;
        }

        #endregion

        #region Unity Methods

        void FixedUpdate()
        {
            if (node == null) return;

            MouseActive.Value = !activeThis;

            CalculateAngle();
            CalculateRelativeAngle();
            CalculateControlAngle();
            AngleValveBody();
            CalculateValue();
        }

        void Awake()
        {
            control = GetComponent<Control>();
            node = GetComponent<Control>().Node;

            OffsetAngle = Mathf.Clamp(OffsetAngle, OffsetAngle, 0);
            MaximumAngle = Mathf.Clamp(MaximumAngle, 0, MaximumAngle);

            MouseClick?.CreateListener(gameObject, MouseHitActivation);
        }

        #endregion
    }
}