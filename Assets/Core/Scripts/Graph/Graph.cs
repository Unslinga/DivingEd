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
using XNode;

namespace Core
{
    [CreateAssetMenu(menuName = "Graph/Graph", order = 0)]
    public class Graph : NodeGraph
    {
        #region Fields & Properties

        public GameManager Manager { get; set; }

        public BaseNode Current { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        public void CreateGameManager()
        {
            Manager = GameManager.Instance;
            Manager.Graph = this;
        }

        #endregion

        #region Unity Methods

        #endregion
    }
}