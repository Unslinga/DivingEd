using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Variables/Float", order = 2)]
    public class FloatVariable : ScriptableObject
    {
        [field: SerializeField]
        public float Value { get; set; }
    }
}