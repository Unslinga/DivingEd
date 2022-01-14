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
using UnityEditor;

namespace Core
{
    [Serializable]
    [CreateAssetMenu(menuName = "Networking/NetworkEventsNamedSet", order = 0)]
    public class NetworkEventsNamedSet : NamedSet<NetworkEvent>
    {
        #region Public Methods

        public NetworkEvent this[int index]
        {
            get
            {
                if (index >= Items.Count)
                    return null;

                return Items[index];
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].ID = i;
            }
        }

        #endregion
    }
}
