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

namespace Core
{
    [Serializable]
    [CreateAssetMenu(menuName = "Networking/NetworkEventsNamedSet", order = 0)]
    public class NetworkEventsNamedSet : NamedSet<NetworkEvent> { }
}
