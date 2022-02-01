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
    [CreateAssetMenu(menuName = "Variables/Vector3", order = 0)]
    public class Vector3Variable : ScriptableObject
    {
        public Vector3 Value;

        public static implicit operator Vector3(Vector3Variable variable)
        {
            return variable.Value;
        }
    }
}