// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Networking
{
    [CustomEditor(typeof(Client))]
    public class ClientConnectButton : Editor
    {
        #region Public Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            Client client = (Client)target;
            if (GUILayout.Button("Connect"))
            {
                client.Connect();
            }
        }

        #endregion

    }    
}
