// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Core
{
    [CreateAssetMenu(menuName = "Networking/NetworkClientRuntimeSet", order = 2)]
    public class NetworkClientsRuntimeSet : RuntimeSet<NetworkClient>
    {
        #region Fields

        #endregion

        #region Properties
        public NetworkClient this[string id]
        {
            get
            {
                var client = Items?.SingleOrDefault(c => c.ID == id);

                if (client == null || client == default)
                {
                    Debug.Log($"[{id}] not found in {this.name}");
                }

                return client;
            }
        }
        #endregion

        #region Public Methods

        #endregion
    }
}