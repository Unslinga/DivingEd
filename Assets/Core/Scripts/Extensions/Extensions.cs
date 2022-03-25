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
    public static class Extensions
    {
        public static T ParseCommand<T>(this object commandDataObject)
        {
            try
            {
                CommandData data = (CommandData)commandDataObject;

                T result = default;

                foreach ((SupportedParameter type, string value) in data.Parameters)
                {
                    switch (type)
                    {
                        case SupportedParameter.String:
                            result = (T)Convert.ChangeType(value, typeof(string));
                            break;
                        case SupportedParameter.Bool:
                            result = (T)Convert.ChangeType(value, typeof(bool));
                            break;
                        case SupportedParameter.Int:
                            result = (T)Convert.ChangeType(value, typeof(int));
                            break;
                        case SupportedParameter.Float:
                            result = (T)Convert.ChangeType(value, typeof(float));
                            break;
                        case SupportedParameter.Double:
                            result = (T)Convert.ChangeType(value, typeof(double));
                            break;
                    }
                }

                return result;
            }
            catch (InvalidCastException)
            {
                Debug.LogError("Invalid Cast! Object might not be CommandData!");
            }

            return default;
        }

        public static object GetOutputValue(this NodePort port)
        {
            return port.Connection != null ? GetInputValue(port.Connection) : null;
        }

        public static object[] GetOutputValues(this NodePort port)
        {
            object[] array = new object[port.ConnectionCount];
            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort other = port.GetConnections()[i];
                array[i] = other != null ? GetInputValue(other) : null;
            }
            return array;
        }

        public static T GetOutputValue<T>(this NodePort port)
        {
            object outputValue = GetOutputValue(port);
            return (outputValue is T t) ? t : default;
        }

        public static T[] GetOutputValues<T>(this NodePort port)
        {
            object[] outputValues = GetOutputValues(port);
            T[] result = new T[outputValues.Length];
            for (int i = 0; i < outputValues.Length; i++)
            {
                if (outputValues[i] is T) result[i] = (T)outputValues[i];
            }
            return result;
        }

        public static object GetInputValue(this NodePort port)
        {
            if (port.direction == NodePort.IO.Output)
            {
                return null;
            }
            return port.node.GetValue(port);
        }
    }
}