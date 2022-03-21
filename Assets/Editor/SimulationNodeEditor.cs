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

    private SerializedProperty flowIn;
    private SerializedProperty flowOut;

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        if (simuationNode == null) simuationNode = target as SimuationNode;

        //flowIn = serializedObject.FindProperty("In");
        //flowOut = serializedObject.FindProperty("Out");

        //if (flowIn != null)
        //{
        //    NodeEditorGUILayout.PortField(new Vector2(0, 32), new NodePort("Test",
        //        typeof(Simulation.Flow),
        //        NodePort.IO.Input, 
        //        Node.ConnectionType.Override, 
        //        Node.TypeConstraint.Inherited, 
        //        simuationNode));
        //}
        //if (flowOut != null)
        //{
        //    NodeEditorGUILayout.PortField(new Vector2(GetWidth() - 16, 32), new NodePort("",
        //        typeof(Simulation.Flow),
        //        NodePort.IO.Output,
        //        Node.ConnectionType.Override,
        //        Node.TypeConstraint.Inherited,
        //        simuationNode));
        //}

        base.OnBodyGUI();

    }

    #endregion
}