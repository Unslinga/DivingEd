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

namespace Networking
{
    [Serializable]
    public class NetworkEvents : MonoBehaviour
    {
        #region Properties
        [field: SerializeField]
        public NetworkEvent ServerStarted { get; set; }
        #endregion
    } 
}