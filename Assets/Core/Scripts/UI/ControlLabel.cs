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
using TMPro;
using UnityEngine;

namespace Core
{
    public class ControlLabel : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public Vector3 Position { get; set; }

        [field: SerializeField]
        public string Label { get; set; }

        private Transform positionChild;
        private TMP_Text text;

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void PositionLabel()
        {
            if (positionChild == null) positionChild = transform.Find("PositionChild");

            positionChild.localPosition = Position;

            if (text == null) text = GetComponentInChildren<TMP_Text>();

            text.text = Label;
        }

        #endregion

        #region Unity Methods

        void OnValidate()
        {
            PositionLabel();
        }

        void Start()
        {
            PositionLabel();
        }

        #endregion
    }
}