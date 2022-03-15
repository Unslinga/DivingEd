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
using UnityEngine.UI;

namespace Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterZoomedUIControl : MonoBehaviour
    {
        #region Fields & Properties

        public Character Character { get; private set; }

        [field: SerializeField]
        [field: ReadOnlyField]
        public float Alpha { get; set; } = 0;

        [field: SerializeField]
        public Image Up { get; set; }
        [field: SerializeField]
        public Image Down { get; set; }
        [field: SerializeField]
        public Image Left { get; set; }
        [field: SerializeField]
        public Image Right { get; set; }

        private Camera cam;

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void ResizeImages()
        {
            var aspect = cam.pixelHeight / (float)cam.pixelWidth;
            var heightPercentage = cam.pixelHeight * Character.EdgeMovePercent / 100;
            var widthPercentage = cam.pixelWidth * Character.EdgeMovePercent * aspect / 100;

            Up.rectTransform.sizeDelta = new Vector2(0, heightPercentage);
            Down.rectTransform.sizeDelta = new Vector2(0, heightPercentage);
            Left.rectTransform.sizeDelta = new Vector2(widthPercentage, 0);
            Right.rectTransform.sizeDelta = new Vector2(widthPercentage, 0);
        }

        private void SetAlpha()
        {
            Alpha = Character.Zoomed ? 1f : 0f;
        }

        #endregion

        #region Unity Methods

        void Start()
        {
            cam = Camera.main;

            Character = gameObject.GetComponent<Character>();

            ResizeImages();
        }

        void Update()
        {
            SetAlpha();
        }

        #endregion
    }
}