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
    [Serializable]
    public class Frame
    {
        #region Fields & Properties

        public double S;
        public int F;

        [SerializeField]
        private double s_l;
        [SerializeField]
        private int f_l;

        public static Frame operator +(Frame a, Frame b)
            => new Frame(a.F + b.F);

        #endregion

        #region Constructor

        public Frame(int f)
        {
            f = Math.Max(f, 0);

            F = f;
            S = FramesToSeconds(f);
        }

        public Frame(double s)
        {
            s = Math.Max(s, 0);

            F = SecondsToFrames(s);
            S = FramesToSeconds(F); 
        }

        #endregion

        #region Public Static Methods
        
        public static int SecondsToFrames(double seconds)
        {
            return (int)(seconds / (double)Time.fixedDeltaTime);
        }

        public static double FramesToSeconds(int frames)
        {
            return frames * (double)Time.fixedDeltaTime;
        }

        #endregion
    }
}