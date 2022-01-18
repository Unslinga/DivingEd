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
    [CreateAssetMenu(menuName = "Variables/int", order = 0)]
    public class IntVariable : ScriptableObject
    {
        public int Value;

        public static implicit operator int(IntVariable variable)
        {
            return variable.Value;
        }
    }
}