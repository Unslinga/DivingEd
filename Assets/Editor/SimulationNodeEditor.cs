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
using UnityEditor;
using XNode;
using XNodeEditor;

[CustomNodeEditor(typeof(SimuationNode))]
public class SimulationNodeEditor : BaseNodeEditor
{
    #region Fields & Properties

    private SimuationNode simuationNode;

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        if (simuationNode == null) simuationNode = target as SimuationNode;

        //NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("controlIn"));
        //NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("controlOut"));
        //NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("in"));
        //NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("out"));

        base.OnBodyGUI();

    }

    #endregion
}