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
    public class DoubleReference
    {
        public bool UseConstant;
        public double ConstantValue;

        public DoubleVariable Variable;

        public double Value
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

        public static implicit operator double(DoubleReference reference)
        {
            return reference.Value;
        }
    }
}