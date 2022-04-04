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

namespace Core
{
    [ExecuteInEditMode]
    public class SnapPoint : MonoBehaviour
    {
        #region Fields & Properties

        [field: SerializeField]
        public GameObject SnapObject { get; set; }

        public GameObject Child { get; set; }

        #endregion

        #region Unity Methods

        void Start()
        {
            if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            Child = transform.Find("Indicator").gameObject;

            if (SnapObject == null)
            {
                Child.SetActive(true);

                return;
            }

            Child.SetActive(false);

            SnapObject.transform.position = transform.position;
        }

        #endregion
    }
}