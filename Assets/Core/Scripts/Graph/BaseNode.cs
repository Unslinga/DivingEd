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
using XNode;

namespace Core
{
    public abstract class BaseNode : Node
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public T GetNode<T>(string portName) where T : BaseNode
        {
            return (T)GetPort(portName).Connection.node;
        }

        public T GetOutputValue<T>(string fieldName, T fallback = default(T))
        {
            NodePort port = GetPort(fieldName);
            if (port?.IsConnected ?? false)
            {
                return port.GetOutputValue<T>();
            }

            return fallback;
        }

        public T[] GetOutputValues<T>(string fieldName, params T[] fallback)
        {
            NodePort port = GetPort(fieldName);
            if (port?.IsConnected ?? false)
            {
                return port.GetOutputValues<T>();
            }

            return fallback;
        }

        public virtual string GetValues() { return default; }

        public virtual void SetValues(string data) { }

        #endregion
    }
}