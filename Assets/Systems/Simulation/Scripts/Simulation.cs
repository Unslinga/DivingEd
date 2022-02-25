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
    public class Simulation : MonoBehaviour, IController
    {
        #region Fields & Properties

        private bool mainTick;

        private List<ITickable> tickables = new List<ITickable>();

        public InputNode InputNode { get; private set; }

        public OutputNode OutputNode { get; private set; }

        [field: SerializeField]
        public List<ISimulationNode> SimulationNodes { get; set; } = new List<ISimulationNode>();

        #endregion

        #region Public Methods

        public void Load()
        {

        }

        public void Save()
        {

        }

        public void Register(ITickable tickable)
        {
            if (tickables.Contains(tickable))
                return;

            tickables.Add(tickable);
        }

        public void Unregister(ITickable tickable)
        {
            if (!tickables.Contains(tickable))
                return;

            tickables.Remove(tickable);
        }

        public IEnumerator MainTick()
        {
            foreach (var tickable in tickables)
            {
                tickable.MainTick();
                yield return null;
            }
        }

        public IEnumerator SubTick()
        {
            foreach (var tickable in tickables)
            {
                tickable.SubTick();
                yield return null;
            }
        }

        public void Tick()
        {
            mainTick = !mainTick;

            StartCoroutine(mainTick ? MainTick() : SubTick());
        }

        #endregion

        #region Private Methods

        private void CreateNode()
        {

        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            InputNode = Instantiate(InputNode);
            OutputNode = Instantiate(OutputNode);

            Load();
        }

        void FixedUpdate()
        {
            Tick();
        }

        #endregion
    }
}