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

namespace Core
{
    [ExecuteInEditMode]
    [Serializable]
    public class BezierCurve : MonoBehaviour
    {
        #region Fields & Properties
        [field: Header("Main Handles")]

        [field: SerializeField]
        public Transform Anchor1 { get; set; }

        [field: SerializeField]
        public Transform Anchor2 { get; set; }
        
        [field: SerializeField]
        public float Control1Distance { get; set; }

        [field: SerializeField]
        [field: ReadOnlyField]
        public Transform Control1 { get; set; }

        [field: SerializeField]
        public float Control2Distance { get; set; }

        [field: SerializeField]
        [field: ReadOnlyField]
        public Transform Control2 { get; set; }

        [field: Header("Settings")]

        [field: Range(2, 1000)]
        [field: SerializeField]
        public int Segments { get; set; }

        [field: Header("Visualization")]

        [field: SerializeField]
        public bool DrawGizmos { get; set; }

        [field: Range(0, 1)]
        [field: SerializeField]
        public float VisualPosition { get; set; }

        [field: Header("Curve Info")]
        [field: SerializeField]
        [field: ReadOnlyField]
        public float TotalArcLength { get; set; }

        public List<BezierPoint> Points { get; private set; } = new List<BezierPoint>();

        public List<float> DistanceLookup { get; set; } = new List<float>();

        #endregion

        #region Public Methods

        public void CalculateCurve()
        {
            Validate();
            FillPoints();
            CalculateArcLengths();
            RemapPoints();
        }

        #endregion

        #region Private Methods

        private float CalculateArcLengths()
        {
            DistanceLookup.Clear();

            float distance = 0f;

            if (Points == null || Points.Count < 2)
                return distance;

            var current = Points[0].position;
            for (int i = 1; i < Points.Count; i++)
            {
                distance += Vector3.Distance(current, Points[i].position);
                DistanceLookup.Add(distance);

                current = Points[i].position;
            }

            TotalArcLength = distance;
            return distance;
        }

        private Vector3 CubicCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            return  p0 * (-Mathf.Pow(t, 3) + 3 * Mathf.Pow(t, 2) - 3 * t + 1) +
                    p1 * (3 * Mathf.Pow(t, 3) - 6 * Mathf.Pow(t, 2) + 3 * t) +
                    p2 * (-3 * Mathf.Pow(t, 3) + 3 * Mathf.Pow(t, 2)) +
                    p3 * Mathf.Pow(t, 3);
        }

        private Vector3 CubucCurveVelocity(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            return  p0 * (-3 * Mathf.Pow(t, 2) + 6 * t - 3) +
                    p1 * (9 * Mathf.Pow(t, 2) - 12 * t + 3) +
                    p2 * (-9 * Mathf.Pow(t, 2) + 6 * t) +
                    p3 * (3 * Mathf.Pow(t, 3));
        }

        private float DistanceToT(float distance)
        {
            if (distance <= 0 ) return 0;

            for (int i = 1; i < DistanceLookup.Count; i++)
            {
                if (distance > DistanceLookup[i - 1] && distance <= DistanceLookup[i])
                {
                    Debug.Log($"Hit: {i}, d: [{distance}], dl: [{DistanceLookup[i]}]");
                    return DistanceLookup[i] / TotalArcLength;
                }
            }

            return 1;
        }

        private void FillPoints()
        {
            Points.Clear();

            Points.Add(new BezierPoint { position = Anchor1.position });

            for (int i = 0; i < Segments; i++)
            {
                Points.Add(new BezierPoint
                {
                    position =
                    CubicCurve(
                        Anchor1.position,
                        Control1.position,
                        Control2.position,
                        Anchor2.position,
                        (float)i / Segments)
                });
            }

            Points.Add(new BezierPoint { position = Anchor2.position });
        }

        private float TToDistance(float t)
        {
            if (t <= 0f)
                return 0f;

            if (t >= 1f)
                return 1f;

            return t * TotalArcLength;
        }

        private void RemapPoints()
        {
            for (int i = 1; i < Points.Count - 1; i++)
            {
                var tmp = Points[i].position;
                Points[i].position = CubicCurve(
                    Anchor1.position,
                    Control1.position,
                    Control2.position,
                    Anchor2.position,
                    DistanceToT(TToDistance((float)i / Segments)));
                Debug.Log($"t: [{(float)i / Segments}], td: [{TToDistance((float)i / Segments)}], dt: [{DistanceToT(TToDistance((float)i / Segments))}]");
                Debug.Log($"prev: [{tmp}], new: [{Points[i].position}]");
            }
        }

        private void Validate()
        {
            if (Anchor1 == null)
            {
                var go = new GameObject();
                go.name = "a1";
                go.transform.parent = transform;
                Anchor1 = go.transform;
            }
            if (Anchor2 == null)
            {
                var go = new GameObject();
                go.name = "a2";
                go.transform.parent = transform;
                Anchor2 = go.transform;
            }
            if (Control1 == null)
            {
                var go = new GameObject();
                go.name = "c1";
                go.transform.parent = transform;
                go.hideFlags = HideFlags.HideInInspector; 
                Control1 = go.transform;
            }
            if (Control2 == null)
            {
                var go = new GameObject();
                go.name = "c2";
                go.transform.parent = transform;
                go.hideFlags = HideFlags.HideInInspector;
                Control2 = go.transform;
            }

            Control1.position = Anchor1.position + Anchor1.up * Control1Distance;
            Control2.position = Anchor2.position + Anchor2.up * Control2Distance;
        }

        #endregion

        #region Unity Methods

        void OnValidate()
        {
            Validate();
            CalculateCurve();
        }

        void OnDrawGizmos()
        {
            if (!DrawGizmos)
                return;

            Gizmos.DrawLine(Anchor1.position, Control1.position);
            Gizmos.DrawLine(Anchor2.position, Control2.position);



            if (Points == null)
                return;

            Points.ForEach(p =>
            {
                Gizmos.DrawIcon(p.position, "target.png", true);
            });
        }

        #endregion
    }
}