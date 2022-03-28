using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Core;

public class Test : MonoBehaviour
{
    public StringVariable test;

    public void Testing()
    {
        Debug.Log("Test");
    }


    private void Start()
    {
        test = UnityEngine.ScriptableObject.CreateInstance<StringVariable>();
    }

}
