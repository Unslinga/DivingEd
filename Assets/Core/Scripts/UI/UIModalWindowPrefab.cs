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
using Object = UnityEngine.Object;

namespace Core
{
    public class UIModalWindowPrefab : MonoBehaviour
    {
        #region Fields



        #endregion

        #region Properties

        [field: Header("Modal Content")]
        [field: SerializeField]
        public GameObject HeaderPrefab { get; set; }
        [field: SerializeField]
        public GameObject ContentPrefab { get; set; }
        [field: SerializeField]
        public bool Vertical { get; set; }
        [field: SerializeField]
        public GameObject FooterPrefab { get; set; }

        public GameObject Modal { get; set; }
        public GameObject Header { get; set; }
        public GameObject HorizontalConent { get; set; }
        public GameObject VerticalConent { get; set; }
        public GameObject Footer { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        public void ValidateHeader()
        {
            if (Header == HeaderPrefab)
            {
                Debug.LogError("Self referencing Header");
            }

            if (HeaderPrefab == null)
            {
                for (int i = 0; i < Header.transform.childCount; i++)
                {
                    Debug.Log("Removed Prefab in hierarchy.");
                    Destroy(Header.transform.GetChild(i).gameObject);
                }
            }
            else
            {
                for (int i = 0; i < Header.transform.childCount; i++)
                {
                    if (Header.transform.GetChild(i) == HeaderPrefab)
                    {
                        return;
                    }
                }
                Debug.Log("Instantiated Prefab in hierarchy.");
                Instantiate(HeaderPrefab, Header.transform);
            }
        }

        #endregion

        #region Unity Methods

        void OnValidate()
        {
            Modal = GameObject.FindGameObjectWithTag("UI-Modal");
            Header = GameObject.FindGameObjectWithTag("UI-Modal-Header");
            HorizontalConent = GameObject.FindGameObjectWithTag("UI-Modal-Content-Horizontal");
            VerticalConent = GameObject.FindGameObjectWithTag("UI-Modal-Content-Vertical");
            Footer = GameObject.FindGameObjectWithTag("UI-Modal-Footer");

            ValidateHeader();

        }

        #endregion
        
    }
}