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
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Console
{
    public class Console : MonoBehaviour
    {
        #region Fields
        #endregion

        #region Properties
        [field: SerializeField]
        public TMP_Text Log { get; set; }

        [field: SerializeField]
        public ConsoleRuntimeSet RuntimeSet { get; set; }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private string FetchText()
        {
            return RuntimeSet?.Items.Aggregate(
                (cur, item) => cur + "\n" + item);
        }
        #endregion

        #region Unity Methods
        private void Start()
        {
            
        }

        private void Update()
        {
            //Log.text = FetchText();
        }
        #endregion
        
    } 
}