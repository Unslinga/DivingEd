using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Variables/Int", order = 2)]

    public class IntVariable : ScriptableObject
    {
        [field: SerializeField]
        public float Value { get; set; }
    }
}