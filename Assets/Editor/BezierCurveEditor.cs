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
using UnityEditor;
using UnityEngine;

namespace Core
{
    [CustomEditor(typeof(BezierCurve))]
    public class BezierCurveEditor : Editor
    {
        private bool enabled = true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(30);
            

            BezierCurve curve = (BezierCurve)target;

            enabled = GUI.enabled;

            if (GUILayout.Button("Update"))
            {
                curve.CalculateCurve();
            }

            GUI.enabled = enabled;
        }
    }
}