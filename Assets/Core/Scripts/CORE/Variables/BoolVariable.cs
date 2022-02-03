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
    [CreateAssetMenu(menuName = "Variables/bool", order = 0)]
    public class BoolVariable : ScriptableObject
    {
        public bool Value;

        public static implicit operator bool(BoolVariable variable)
        {
            return variable.Value;
        }
    }
}