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
    [CreateAssetMenu(menuName = "Variables/string", order = 0)]
    public class StringVariable : ScriptableObject
    {
        public string Value;

        public static implicit operator string(StringVariable variable)
        {
            return variable.Value;
        }
    }
}