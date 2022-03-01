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
    public interface ISimulationNode : ITickable
    {
        #region Fields & Properties

        string ID { get; set; }

        List<ISimulationNode> Previous { get; set; }
        
        List<ISimulationNode> Next { get; set; }

        Flow Flow { get; set; }

        #endregion

        #region Public Methods



        #endregion
    }
}