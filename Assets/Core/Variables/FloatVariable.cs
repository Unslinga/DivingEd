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
    [CreateAssetMenu(menuName = "Variables/float", order = 2)]
    public class FloatVariable : ScriptableObject
    {
        public float Value;

        public static implicit operator float(FloatVariable variable)
        {
            return variable.Value;
        }
    }
}