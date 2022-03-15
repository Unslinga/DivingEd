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
    public class NetworkEvent : BaseEvent
    {
        #region Properties

        [field: ReadOnlyField]
        [field: SerializeField]
        public int ID { get; set; }

        [field: SerializeField]
        public UnityAction<Packet, object[]> SendMethod { get; set; }

        #endregion

        #region Unity Methods

        void Awake()
        {
            Validate();
        }

        void OnValidate()
        {
            Validate();
        }

        #endregion
    }
}
