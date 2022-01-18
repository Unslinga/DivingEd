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

        #endregion

        #region Private Methods

        public void ValidateList()
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                Items[i].ID = i;
            }
        }

        #endregion

        #region Unity Methods

        public void OnValidate()
        {
            ValidateList();
        }

        #endregion
    }
}
