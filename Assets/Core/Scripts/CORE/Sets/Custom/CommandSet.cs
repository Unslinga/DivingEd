// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    [CreateAssetMenu(menuName = "Console/CommandSet", order = 0)]
    public class CommandSet : NamedSet<CommandEvent>
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

        #region Unity Methods

        void OnEnable()
        {
            //GlobalSetInstance.Register(this); // This needs a lot more work.
        }

        #endregion

    }
}
