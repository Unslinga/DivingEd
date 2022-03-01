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
    [CreateAssetMenu(menuName = "Simulation/IONode", order = 0)]
    public class IONode : ScriptableObject, ISimulationNode
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

        [field: Header("Info")]

        [field: SerializeField]
        [field: ReadOnlyField]
        public string ID { get; set; }

        [field: Header("Nodes")]

        [field: SerializeField]
        public List<ISimulationNode> Previous { get; set; }

        [field: SerializeField]
        public List<ISimulationNode> Next { get; set; }

        [field: Space(10)]
        
        [field: SerializeField]
        public Flow Flow { get; set; }

        [field: SerializeField]
        public DoubleReference Control { get; set; }

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

        void ITickable.MainTick()
        {
            throw new NotImplementedException();
        }

        void ITickable.SubTick()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
