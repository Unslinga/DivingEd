using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class FloatReference
    {
        [field: SerializeField]
        public bool UseConstant { get; set; }

        [field: SerializeField]
        public float ConstantValue { get; set; }

        [field: SerializeField]
        public FloatVariable Variable { get; set; }

        public float Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
            set
            {
                if (UseConstant)
                    ConstantValue = value;
                else
                    Variable.Value = value;
            }
        }
    }

}