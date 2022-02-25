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
    [Serializable]
    [CreateAssetMenu(menuName = "Simulation/SimulationNode", order = 0)]
    public class IOSimulationNode : ScriptableObject, ITickable, ISimulationNode
    {
        #region Fields & Properties

        private IController controller;
        public IController Controller
        {
            get { return controller; }
            set
            {
                controller = value;
                controller.Register(this);
            }
        }

        [field: Header("Node")]

        [field: SerializeField]
        public IOSimulationNode Next { get; set; }

        [field: SerializeField]
        public NodeElement NodeElement { get; set; }

        [field: Space(10)]
        [field: Header("Flow")]

        [field: SerializeField]
        public DoubleReference Control { get; set; }

        [field: SerializeField]
        public DoubleReference PressureIn { get; private set; }

        [field: SerializeField]
        public DoubleReference PressureOut { get; private set; }

        [field: SerializeField]
        public DoubleReference FeedbackIn { get; private set; }

        [field: SerializeField]
        public DoubleReference FeedbackOut { get; private set; }

        #endregion

        #region Public Methods

        public void Calculate()
        {

        }

        public void Update()
        {

        }

        public void MainTick()
        {
            Calculate();
        }

        public void SubTick()
        {
            Update();
        }

        #endregion

        #region Unity Methods

        void OnDestroy()
        {
            controller.Unregister(this);
        }

        #endregion
    }
}
