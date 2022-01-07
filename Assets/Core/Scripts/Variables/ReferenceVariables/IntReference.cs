using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class IntReference
    {
        [field: SerializeField]
        public bool UseConstant { get; set; }

        [field: SerializeField]
        public int ConstantValue { get; set; }

        [field: SerializeField]
        public IntVariable Variable { get; set; }

        public int Value
        {
            get
            {
                return (int)(UseConstant ? ConstantValue : Variable.Value);
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
}
