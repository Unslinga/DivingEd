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

namespace Character
{
    [RequireComponent(typeof(Image))]
    public class SpriteAlphaChanger : MonoBehaviour
    {
        #region Fields & Properties

        public CharacterZoomedUIControl Control { get; private set; }

        public float DefaultAlpha { get; set; }

        public Image Image { get; private set; }
        
        #endregion

        #region Unity Methods

        void Start()
        {
            Control = GetComponentInParent<CharacterZoomedUIControl>();
            Image = GetComponent<Image>();
            DefaultAlpha = Image.color.a;
        }

        void Update()
        {
            var col = Image.color;
            col.a = Control.Alpha * DefaultAlpha;
            Image.color = col;
        }

        #endregion
    }
}