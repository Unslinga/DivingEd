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

namespace Core
{
    [Serializable]
    [CreateAssetMenu(menuName = "Simulation/SimulationNode", order = 0)]
    public class SimulationNode : ScriptableObject
    {
        #region Fields

        #endregion

        #region Properties

        [field: Header("Nodes")]
        [field: SerializeField]
        public SimulationNode Next { get; set; }

        [field: Space(10)]
        [field: Header("Flow")]
        [field: SerializeField]
        public DoubleReference PressureIn { get; set; }

        [field: SerializeField]
        public DoubleReference PressureOut { get; set; }

        [field: SerializeField]
        public DoubleReference FeedbackIn { get; set; }

        [field: SerializeField]
        public DoubleReference FeedbackOut { get; set; }

        #endregion

        #region Public Methods



        #endregion

    }    
}
