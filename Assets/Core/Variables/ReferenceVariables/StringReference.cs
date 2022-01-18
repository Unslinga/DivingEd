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
    public class StringReference
    {
        public bool UseConstant;
        public string ConstantValue;

        public StringVariable Variable;

        public string Value
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

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}