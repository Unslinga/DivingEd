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
        #region Fields & Properties

        [field: Header("Input")]
        [field: SerializeField]
        public InputEventSet InputEvents { get; set; }

        [field: SerializeField]
        public Vector2Reference MousePosition { get; set; }

        [field: Header("Camera Zoom Settings")]
        [field: SerializeField]
        public FloatReference CameraFOV { get; set; }

        [field: SerializeField]
        public float NormalZoom { get; set; } = 85;
        [field: SerializeField]
        public float DetailZoom { get; set; } = 25;

        [field: SerializeField]
        public float ZoomDuration { get; set; } = 1f;

        [field: SerializeField]
        [field: ReadOnlyField]
        public bool Zoomed { get; set; } = false;

        [field: Header("Camera Position Settings")]
        [field: SerializeField]
        public Vector3Reference CameraPosition { get; set; }

        [field: SerializeField]
        [field: ReadOnlyField]
        public Vector2 LocalPosition { get; private set; } = Vector3.zero;

        [field: SerializeField]
        [field: Range(1, 100)]
        public float EdgeMovePercent { get; set; }
        [field: SerializeField]
        public float EdgeMoveSpeed { get; set; }

        [field: SerializeField]
        public Vector3 NormalPosition { get; set; } = new Vector3(0f,1.2f,0f);

        [field: SerializeField]
        public Vector3 MaxPosition { get; set; } = new Vector3(0.475f, 2.3f, 0f);

        private bool zooming;
        private byte direction;
        private Camera cam;

        #endregion

        #region Public Methods

        public void ToggleZoomed(object data)
        {
            if (data is MouseInputData)
            {
                var button = (MouseInputData)data;

                if (button.State == 0)
                {
                    Zoomed = !Zoomed;
                    StartCoroutine(Zoom());
                }
            }
            if (data is KeyboardInputData)
            {
                var key = (KeyboardInputData)data;

                if (key.State == 0)
                {
                    Zoomed = !Zoomed;
                    StartCoroutine(Zoom());
                }
            }
        }

        public void MoveUp(object data)
        {
            var key = (KeyboardInputData)data;
            if (key.State == 1)
            {
                direction += 1 << 0;
            }
            else if (key.State == 2)
            {
                direction -= 1 << 0;
            }
        }

        public void MoveDown(object data)
        {
            var key = (KeyboardInputData)data;
            if (key.State == 1)
            {
                direction += 1 << 1;
            }
            else if (key.State == 2)
            {
                direction -= 1 << 1;
            }
        }

        public void MoveLeft(object data)
        {
            var key = (KeyboardInputData)data;
            if (key.State == 1)
            {
                direction += 1 << 2;
            }
            else if (key.State == 2)
            {
                direction -= 1 << 2;
            }
        }

        public void MoveRight(object data)
        {
            var key = (KeyboardInputData)data;
            if (key.State == 1)
            {
                direction += 1 << 3;
            }
            else if (key.State == 2)
            {
                direction -= 1 << 3;
            }
        }

        #endregion

        #region Private Methods

        private void ArrowMovement()
        {
            var pos = LocalPosition;

            pos.y += ((direction & (1 << 0)) != 0) ? EdgeMoveSpeed * 0.75f : 0;
            pos.y -= ((direction & (1 << 1)) != 0) ? EdgeMoveSpeed * 0.75f : 0;
            pos.x += ((direction & (1 << 2)) != 0) ? EdgeMoveSpeed * 0.75f : 0;
            pos.x -= ((direction & (1 << 3)) != 0) ? EdgeMoveSpeed * 0.75f : 0;

            LocalPosition = pos;
        }

        private void MouseMovement()
        {
            var pos = LocalPosition;

            var height = cam.pixelHeight;
            var width = cam.pixelWidth;

            var aspect = height / (float)width;
            var heightPercent = height * EdgeMovePercent / 100;
            var widthPercent = width * EdgeMovePercent * aspect / 100;

            if (MousePosition.Value.x < widthPercent && MousePosition.Value.x > 0)
            {
                pos.x += (widthPercent - MousePosition.Value.x) * EdgeMoveSpeed / widthPercent;
            }
            if (MousePosition.Value.x > width - widthPercent && MousePosition.Value.x < width)
            {
                pos.x -= (widthPercent + (MousePosition.Value.x - width)) * EdgeMoveSpeed / widthPercent;
            }

            if (MousePosition.Value.y < heightPercent && MousePosition.Value.y > 0)
            {
                pos.y -= (heightPercent - MousePosition.Value.y) * EdgeMoveSpeed / heightPercent;
            }
            if (MousePosition.Value.y > height - heightPercent && MousePosition.Value.y < height)
            {
                pos.y += (heightPercent + (MousePosition.Value.y - height)) * EdgeMoveSpeed / heightPercent;
            }

            LocalPosition = pos;
        }

        private void NormalizePosition()
        {
            var pos = LocalPosition;

            if (pos.x > MaxPosition.x)
                pos.x = MaxPosition.x;
            if (pos.x < -MaxPosition.x)
                pos.x = -MaxPosition.x;
            if (pos.y > MaxPosition.y)
                pos.y = MaxPosition.y;
            if (pos.y < -MaxPosition.y)
                pos.y = -MaxPosition.y;

            LocalPosition = pos;
        }

        private IEnumerator Zoom()
        {
            float elapsed = 0;

            float start = Zoomed ? NormalZoom : DetailZoom;
            float end = Zoomed ? DetailZoom : NormalZoom;

            Vector3 startPos = CameraPosition;
            Vector3 endPos = NormalPosition;

            while (elapsed < ZoomDuration)
            {
                float t = elapsed / ZoomDuration;
                t = t * t * (3f - 2f * t);

                CameraFOV.Value = Mathf.Lerp(start, end, t);
                CameraPosition.Value = Vector3.Lerp(startPos, endPos, t);

                elapsed += Time.deltaTime;
                yield return null;
            }

            CameraFOV.Value = end;
            CameraPosition.Value = endPos;
        }

        private void ZoomedMovement()
        {
            if (!Zoomed)
            {
                LocalPosition = Vector2.zero;
                return;
            }

            ArrowMovement();
            MouseMovement();
            NormalizePosition();

            CameraPosition.Value = NormalPosition + (Vector3)LocalPosition;
        }

        #endregion

        #region Unity Methods

        void Start()
        {
            cam = Camera.main;

            CameraFOV.Value = NormalZoom;
            CameraPosition.Value = NormalPosition;

            InputEvents["MiddleClick"].CreateListener(gameObject, ToggleZoomed);
            InputEvents["Zoom"].CreateListener(gameObject, ToggleZoomed);

            InputEvents["ArrowUp"].CreateListener(gameObject, MoveUp);
            InputEvents["ArrowDown"].CreateListener(gameObject, MoveDown);
            InputEvents["ArrowLeft"].CreateListener(gameObject, MoveLeft);
            InputEvents["ArrowRight"].CreateListener(gameObject, MoveRight);
        }

        void Update()
        {
            Zoom();
            ZoomedMovement();
        }

        #endregion

    } 
}