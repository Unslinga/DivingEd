// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Core
{
    public class UITextInputAreaPrefab : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Properties

        [field: Header("Canvas Elements")]

        [field: SerializeField]
        public GameObject Root { get; set; }

        [field: SerializeField]
        public Button SubmitButton { get; set; }

        [field: SerializeField]
        public TMP_InputField InputField { get; set; }

        [field: Header("UI Events")]

        [field: SerializeField]
        public UIEvent TextInputAreaSubmit { get; set; }

        #endregion

        #region Public Methods

        public void OnClick_Submit()
        {
            Debug.Log(InputField.text);
        }

        public void OnSubmit_InputField(string value)
        {
            Debug.Log(value);
        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods
        
        private void Start()
        {
            SubmitButton.onClick.AddListener(OnClick_Submit);
            InputField.onSubmit.AddListener(OnSubmit_InputField);
        }

        private void Update()
        {
            
        }
        #endregion
        
    }
}