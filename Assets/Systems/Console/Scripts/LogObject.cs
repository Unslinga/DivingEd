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
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class LogObject : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        [ReadOnlyField]
        private bool stackTraceActive = false;

        [SerializeField]
        public LogMessageData data;

        #endregion

        #region Properties

        public LogMessageData Data
        {
            get { return data; }
            set
            {
                data = value;
                gameObject.name = data.Name;

                switch (data.Type)
                {
                    case LogType.Error:
                        Color = Color.red;
                        break;
                    case LogType.Warning:
                        Color = Color.yellow;
                        break;
                    case LogType.Exception:
                        Color = Color.red;
                        break;
                    default:
                        break;
                }

                MessageText.text = data.Message;

                TypeText.text = data.Command ? "Command" : data.Type.ToString();
            }
        }

        [field: Space]
        [field: SerializeField]
        public CommandEvent DisplayStackTrace { get; set; }

        [field: Space]
        [field: SerializeField]
        public TMP_Text MessageText { get; set; }

        [field: SerializeField]
        public TMP_Text TypeText { get; set; }

        [field: SerializeField]
        public Button ToggleStackTrace { get; set; }

        public Color Color
        {
            set
            {
                MessageText.color = value;
                TypeText.color = value;
            }
        }

        #endregion

        #region Private Methods

        private void OnDisplayStackTrace(object data)
        {
            var state = ((string name, bool active, string stackTrace))data;
            if (stackTraceActive)
            {
                if (state.name != name)
                {
                    stackTraceActive = false;
                }
            }
        }

        private void OnToggleStackTrace()
        {
            stackTraceActive = !stackTraceActive;

            DisplayStackTrace?.Raise((name, stackTraceActive, data.StackTrace).Compose());
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            DisplayStackTrace.CheckNull(true);
            DisplayStackTrace.CreateListener(gameObject, OnDisplayStackTrace);

            ToggleStackTrace.onClick.AddListener(OnToggleStackTrace);
        }

        #endregion
    }
}