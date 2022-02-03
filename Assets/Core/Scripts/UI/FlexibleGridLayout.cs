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
    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }

    public class FlexibleGridLayout : LayoutGroup
    {
        #region Fields

        #endregion

        #region Properties

        [field: Space]
        [field: SerializeField]
        public FitType FitType { get; set; }

        [field: Space]
        [field: SerializeField]
        public int Rows { get; set; }

        [field: SerializeField]
        public int Columns { get; set; }

        [field: SerializeField]
        public bool FitX { get; set; } = true;

        [field: SerializeField]
        public bool FitY { get; set; } = true;

        [field: Space]
        [field: SerializeField]
        public Vector2 Spacing { get; set; }

        [field: Space]
        [field: SerializeField]
        public Vector2 CellSize { get; set; }

        [field: SerializeField]
        public bool GetChildSize { get; set; }

        #endregion

        #region Public Methods
        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();


            if (transform.childCount == 0)
                return;

            if (FitType != FitType.FixedRows && FitType != FitType.FixedColumns)
            {
                float sqrRoot = Mathf.Sqrt(transform.childCount);

                Rows = Mathf.CeilToInt(sqrRoot);
                Columns = Mathf.CeilToInt(sqrRoot);
            }


            if (FitType == FitType.Width || FitType == FitType.FixedColumns)
            {
                Rows = Mathf.CeilToInt(transform.childCount / (float)Columns);
            }
            if (FitType == FitType.Height || FitType == FitType.FixedRows)
            {
                Columns = Mathf.CeilToInt(transform.childCount / (float)Rows);
            }


            float parentWidth = rectTransform.rect.width;
            float parentHeight = rectTransform.rect.height;

            float cellWidth = (parentWidth / Columns) - ((Spacing.x / Columns) * (Columns - 1))
                - (padding.left / Columns) - (padding.right / Columns);
            float cellHeight = (parentHeight / Rows) - ((Spacing.y / Rows) * (Columns - 1))
                - (padding.top / Rows) - (padding.bottom / Rows);

            cellWidth = FitX ? cellWidth : CellSize.x;
            cellHeight = FitY ? cellHeight : CellSize.y;

            CellSize = new Vector2(cellWidth, cellHeight);

            for (int i = 0; i < rectChildren.Count; i++)
            {
                int rowCnt = i / Columns;
                int columnCnt = i % Columns;

                float xPos = (CellSize.x * columnCnt) + (Spacing.x * columnCnt) + padding.left;
                float yPos = (CellSize.y * rowCnt) + (Spacing.y * rowCnt) + padding.top;

                SetChildAlongAxis(rectChildren[i], 0, xPos, CellSize.x);
                SetChildAlongAxis(rectChildren[i], 1, yPos, CellSize.y);
            }

            SetDirty();
        }

        public override void CalculateLayoutInputVertical()
        {
            
        }

        public override void SetLayoutHorizontal()
        {
            
        }

        public override void SetLayoutVertical()
        {
            
        }

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        #endregion
    }
}