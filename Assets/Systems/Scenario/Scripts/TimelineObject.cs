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
using UnityEngine.Timeline;
using XNode;

namespace Scenario
{
    public class TimelineObject : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public ClipTimeNode Node { get; set; }

        #endregion

        #region Public Methods

        public void CreateMarker()
        {
            Node = GameManager.Instance.Graph.AddNode<ClipTimeNode>();

            Node.SetValues("{\"1\":\"Clip Time\",\"2\":1}");

            Node.UpdateSettings();

            //Debug.Log(node.GetValues());
        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void OnApplicationQuit()
        {
            GameManager.Instance.Graph.RemoveNode(Node);
            Node = null;
        }

        void Start()
        {
            CreateMarker();
        }

        #endregion
    }
}