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

namespace Core
{
    [RequireComponent(typeof(CanvasRenderer))]
    [RequireComponent(typeof(BezierCurve))]
    public class BezierRenderer : Graphic
    {
        #region Fields

        private float halfHeight;
        private float halfWidth;

        #endregion

        #region Properties

        [field: ReadOnlyField]
        [field: SerializeField]
        public float Height { get; set; }

        [field: ReadOnlyField]
        [field: SerializeField]
        public float Width { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        

        #endregion

        #region Unity Methods

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            Height = rectTransform.rect.height;
            halfHeight = Height / 2;

            Width = rectTransform.rect.width;
            halfWidth = Width / 2;

            UIVertex vert = UIVertex.simpleVert;
            vert.color = color;

            vert.position = new Vector3(-halfWidth, -halfHeight);
            vh.AddVert(vert);

            vert.position = new Vector3(-halfWidth, halfHeight);
            vh.AddVert(vert);

            vert.position = new Vector3(halfWidth, halfHeight);
            vh.AddVert(vert);

            vert.position = new Vector3(halfWidth, -halfHeight);
            vh.AddVert(vert);

            vh.AddTriangle(0, 1, 2);
            vh.AddTriangle(2, 3, 0);

        }

        #endregion
    }
}