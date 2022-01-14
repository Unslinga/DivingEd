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
using UnityEngine.Events;

namespace Core
{
    [Serializable]
    [CreateAssetMenu(menuName = "Networking/NetworkEvent", order = 0)]
    public class NetworkEvent : BaseEvent, INetworkEvent
    {
        #region Properties

        [field: ReadOnlyField]
        [field: SerializeField]
        public int ID { get; set; }

        [field: SerializeField]
        public UnityEvent<object[]> SendMethod { get; set; }

        #endregion
    }
}
