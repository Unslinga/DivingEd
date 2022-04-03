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
using TMPro;

namespace Control
{
    public class GaugeNumbering : MonoBehaviour
    {
        #region Fields & Properties

        private Canvas canvas;
        private RectTransform rectTransform;

        [field: SerializeField]
        public GameObject Number { get; set; }
        private GameObject[] numbers;

        [field: Header("Dial Settings")]

        [field: SerializeField]
        public float DialScale { get; set; }

        [field: SerializeField]
        public int AngleStart { get; set; }

        [field: SerializeField]
        public int Segments { get; set; }

        [field: SerializeField]
        public int SegmentStep { get; set; }

        [field: Header("Number Settings")]

        [field: SerializeField]
        public float NumberScale { get; set; }

        [field: SerializeField]
        public int NumberStep { get; set; }

        [field: SerializeField]
        public float Radius { get; set; }

        #endregion

        #region Public Methods

        public void PositionNumbers()
        {
            canvas = GetComponentInChildren<Canvas>();
            rectTransform = canvas.GetComponent<RectTransform>();

            rectTransform.localScale = new Vector3(DialScale, DialScale, 1);

            numbers = new GameObject[Segments];

            int cnt = 0;

            for (int i = 0; i < Segments; i++)
            {
                var number = Instantiate(Number);
                number.transform.SetParent(rectTransform, false);

                var localTransform = number.GetComponent<RectTransform>();

                float angle = (AngleStart + (-i * SegmentStep)) * Mathf.PI / 180;

                localTransform.anchoredPosition = new Vector3(Mathf.Sin(angle) * Radius, Mathf.Cos(angle) * Radius, 0);

                localTransform.localScale = new Vector3(NumberScale, NumberScale, 1);

                number.GetComponent<TMP_Text>().text = cnt.ToString();

                cnt += NumberStep;
                numbers[i] = number;
            }
        }

        #endregion
    }
}