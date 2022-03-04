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
    public class BaseReference<T, U> where U : BaseVariable<T>
    {
        public bool UseConstant;
        public T ConstantValue;

        public U Variable;

        public T Value
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

        public static implicit operator T(BaseReference<T, U> reference)
        {
            return reference.Value;
        }
    }    
}
