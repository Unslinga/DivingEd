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
    [CustomPropertyDrawer(typeof(Frame))]
    public class FrameDrawer : PropertyDrawer
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            label = EditorGUI.BeginProperty(position, label, property);
            label.tooltip = "First time in Seconds, Second time in Frames";

            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            SerializedProperty s = property.FindPropertyRelative("S");
            SerializedProperty s_l = property.FindPropertyRelative("s_l");
            SerializedProperty f = property.FindPropertyRelative("F");
            SerializedProperty f_l = property.FindPropertyRelative("f_l");

            double s_s = s.doubleValue;
            int f_s = f.intValue;

            if (s_s != s_l.doubleValue)
            {
                f.intValue = Frame.SecondsToFrames(s_s);
                s.doubleValue = Frame.FramesToSeconds(f.intValue);
            }
            if (f_s != f_l.intValue)
            {
                s.doubleValue = Frame.FramesToSeconds(f.intValue);
            }

            s_l.doubleValue = s.doubleValue;
            f_l.intValue = f.intValue;

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            Rect srect = new Rect(position);
            srect.width = (position.width / 2) - 2;

            EditorGUI.PropertyField(srect, s, GUIContent.none);

            Rect frect = new Rect(position);
            frect.xMin = 4 + srect.xMax;
            frect.width = (position.width / 2) - 2;

            EditorGUI.PropertyField(frect, f, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        #endregion
    }
}