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
    [CreateAssetMenu(menuName = "Variables/double", order = 0)]
    public class DoubleVariable : ScriptableObject
    {
        public double Value;

        public static implicit operator double(DoubleVariable variable)
        {
            return variable.Value;
        }
    }
}