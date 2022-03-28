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
using UnityEngine.Playables;

public class VariableClip : PlayableAsset
{
    #region Fields & Properties
    public DoubleVariable DoubleV;
    #endregion

    #region Public Methods

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DoubleVariableBehaviour>.Create(graph);

        DoubleVariableBehaviour variableBehaviour = playable.GetBehaviour();

        variableBehaviour.DoubleV = DoubleV;
        return playable;
    }
    #endregion

    #region Private Methods

    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion
}