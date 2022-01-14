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
    public interface INetworkEvent
    {
        #region Properties

        int ID { get; set; }

        UnityEvent<object[]> SendMethod { get; set; }

        #endregion

        #region Public Methods


        #endregion
    } 
}