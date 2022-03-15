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
    public static class Extensions
    {
        public static T1 ParseCommand<T1>(this object commandDataObject)
        {
            try
            {
                CommandData data = (CommandData)commandDataObject;

                T1 result = default;

                foreach ((SupportedParameter type, string value) in data.Parameters)
                {
                    switch (type)
                    {
                        case SupportedParameter.String:
                            result = (T1)Convert.ChangeType(value, typeof(string));
                            break;
                        case SupportedParameter.Bool:
                            result = (T1)Convert.ChangeType(value, typeof(bool));
                            break;
                        case SupportedParameter.Int:
                            result = (T1)Convert.ChangeType(value, typeof(int));
                            break;
                        case SupportedParameter.Float:
                            result = (T1)Convert.ChangeType(value, typeof(float));
                            break;
                        case SupportedParameter.Double:
                            result = (T1)Convert.ChangeType(value, typeof(double));
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
    }
}