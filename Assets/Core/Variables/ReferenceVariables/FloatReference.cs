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
    public class FloatReference
    {
        public bool UseConstant;
        public float ConstantValue;

        public FloatVariable Variable;

        public float Value
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

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}