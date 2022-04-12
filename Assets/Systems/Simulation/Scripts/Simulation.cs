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
using System.Linq;
using UnityEngine;

namespace Simulation
{
    public class Simulation : MonoBehaviour
    {
        #region Fields & Properties

        private static Simulation instance;
        public static Simulation Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Singleton.Create<Simulation>();
                }

                return instance;
            }
        }

        [field: SerializeField]
        public List<InputNode> InputNodes { get; set; }

        #endregion

        #region Public Methods

        public void UpdateNodes()
        {
            InputNodes.ForEach(n => n.ClearCascade(new List<int> { n.ID }));

            InputNodes.ForEach(n => n.CascadeValue(new List<int> { n.ID }));
        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Start()
        {
            InputNodes = GameManager.GetNodesByType<InputNode>();
        }

        void FixedUpdate()
        {
            UpdateNodes();
        }

        #endregion
    }
}