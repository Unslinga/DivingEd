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

namespace Scenario
{
    [CustomEditor(typeof(Scenario))]
    public class ScenarioEditor : Editor
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var export = (Texture)AssetDatabase
                .LoadAssetAtPath("Assets/Unity/Libraries/gameicons/PNG/White/2x/export.png",
                typeof(Texture));
            var import = (Texture)AssetDatabase
                .LoadAssetAtPath("Assets/Unity/Libraries/gameicons/PNG/White/2x/import.png",
                typeof(Texture));
            var play = (Texture)AssetDatabase
                .LoadAssetAtPath("Assets/Unity/Libraries/gameicons/PNG/White/2x/right.png", 
                typeof(Texture));
            var pause = (Texture)AssetDatabase
                .LoadAssetAtPath("Assets/Unity/Libraries/gameicons/PNG/White/2x/pause.png",
                typeof(Texture));
            var restart = (Texture)AssetDatabase
                .LoadAssetAtPath("Assets/Unity/Libraries/gameicons/PNG/White/2x/return.png",
                typeof(Texture));

            var scenario = (Scenario)target;

            GUILayout.Space(8);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button(export, GUILayout.Height(30))) scenario.LoadScenario();

            if (GUILayout.Button(import, GUILayout.Height(30))) scenario.SaveScenario();

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            if (GUILayout.Button(play, GUILayout.Height(40))) scenario.Play();

            if (GUILayout.Button(pause, GUILayout.Height(40))) scenario.Pause();

            if (GUILayout.Button(restart, GUILayout.Height(40))) scenario.Restart();

            GUILayout.EndHorizontal();
        }

        #endregion
    }
}