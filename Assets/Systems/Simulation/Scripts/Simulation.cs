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
        public SimulationNode InputNodes { get; set; }

        #endregion

        #region Public Methods

        public void UpdateNodes()
        {

        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Awake()
        {

        }

        void FixedUpdate()
        {

        }

        #endregion
    }
}