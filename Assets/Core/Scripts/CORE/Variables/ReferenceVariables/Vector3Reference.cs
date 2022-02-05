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
    public class Vector3Reference
    {
        public bool UseConstant;
        public Vector3 ConstantValue;

        public Vector3Variable Variable;

        public Vector3 Value
        {
            get
            {
                return UseConstant || Variable == null ? ConstantValue : Variable.Value;
            }
            set
            {
                if (Variable != null)
                    Variable.Value = value;
                ConstantValue = value;
            }
        }

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}