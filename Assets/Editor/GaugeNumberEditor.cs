// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using Control;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core
{
    [CustomEditor(typeof(GaugeNumbering))]
    public class GaugeNumberEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GaugeNumbering gauge = (GaugeNumbering)target;

            GUILayout.Space(16);

            if (GUILayout.Button("Create dial numbers"))
            {
                gauge.PositionNumbers();
            }

        }
    }
}