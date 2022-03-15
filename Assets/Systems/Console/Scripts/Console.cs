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
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Console
{
    [RequireComponent(typeof(ConsoleLogging))]
    public class Console : MonoBehaviour
    {
        #region Fields

        private Vector2 scrollPosition;
        private const float smoothLerpDuration = 0.25f;

        #endregion

        #region Properties

        [field: SerializeField]
        public CommandSet ConsoleCommands { get; set; }

        [field: SerializeField]
        public LogSet LogSet { get; set; }

        [field: Space]
        [field: SerializeField]
        public GameObject LogPrefab { get; set; }

        [field: Space]
        [field: SerializeField]
        public bool SmoothScroll { get; set; } = true;

        [field: Header("UI Elements")]

        [field: SerializeField]
        public TMP_InputField CommandLine { get; set; }

        [SerializeField]
        private GameObject consoleWindow;
        public bool ConsoleWindowActive
        {
            get
            {
                return consoleWindow.activeSelf;
            }
            set
            {
                consoleWindow.SetActive(value);

                if (value)
                {
                    FocusCommandLine();
                }
            }
        }

        [field: SerializeField]
        public GameObject Content { get; set; }

        [field: SerializeField]
        public Button Close { get; set; }

        [field: SerializeField]
        public ScrollRect ScrollRect { get; set; }

        [field: SerializeField]
        public GameObject StackTrace { get; set; }
        public TMP_Text StackTraceText { get { return StackTrace.GetComponentInChildren<TMP_Text>(); } }

        [field: SerializeField]
        public Button Submit { get; set; }

        #endregion

        #region Public Methods

        public void ToggleActive()
        {
            ConsoleWindowActive = !ConsoleWindowActive;
        }

        public void ToggleActive(bool active)
        {
            ConsoleWindowActive = active;
        }

        #endregion

        #region Private Methods

        private void FocusCommandLine()
        {
            CommandLine.ActivateInputField();
        }

        private void OnClick_Close()
        {
            ToggleActive(false);
        }

        private void OnClick_Submit()
        {
            if (CommandLine.text == "")
                return;

            OnSubmit_CommandLine(CommandLine.text);
        }

        private void OnDisplayStackTrace(object data)
        {
            var state = ((string name, bool active, string stackTrace))data;

            StackTrace.SetActive(state.active);
            StackTraceText.text = state.stackTrace;
        }    

        private void OnLogToConsole(object data)
        {
            var message = (LogMessageData)data;
            message.Name = $"Log_Debug_{LogSet.Count}";

            var logObject = Instantiate(LogPrefab, Content.transform).GetComponent<LogObject>();
            logObject.Data = message;

            LogSet.Add(logObject.gameObject);

            scrollPosition = ScrollRect
                        .GetVerticalSnapPositionOfChild(logObject.GetComponent<RectTransform>());

            StartCoroutine(Scroll());
        }

        private void OnMessageToConsole(object data)
        {
            Debug.Log(data.ParseCommand<string>());
        }

        private void OnSubmit_CommandLine(string input)
        {
            CommandLine.text = "";
            FocusCommandLine();

            string[] inputs = input.Split(' ');

            var command = ConsoleCommands[inputs[0]];

            if (command == null)
                return;

            ConsoleCommands["LogToConsole"]?.
                Raise(new LogMessageData 
                { 
                    Type = LogType.Log, 
                    Message = input, 
                    StackTrace = inputs.Aggregate("", (c, n) => c + n + "\n"),
                    Command = true
                });

            command.Raise(inputs.Skip(1).ToArray());
        }

        private IEnumerator Scroll()
        {
            if (SmoothScroll)
            {
                float time = 0;
                Vector2 start = ScrollRect.content.localPosition;

                while (time < smoothLerpDuration)
                {
                    ScrollRect.content.localPosition = Vector2.Lerp(start, scrollPosition, time);
                    time += Time.deltaTime;
                    yield return null;
                }

            }

            ScrollRect.content.localPosition = scrollPosition;
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            ConsoleCommands.CheckNull(true);
            LogSet.CheckNull(true);

            foreach (var command in ConsoleCommands.Items)
            {
                command.CheckNull(true);
            }

            LogSet.Clear();

            ConsoleCommands["DisplayStackTrace"]?.CreateListener(gameObject, OnDisplayStackTrace);
            ConsoleCommands["LogToConsole"]?.CreateListener(gameObject, OnLogToConsole);

            ConsoleCommands["MessageToConsole"]?.CreateListener(gameObject, OnMessageToConsole);

            Close.CheckNull(true);
            Close.onClick.AddListener(OnClick_Close);

            CommandLine.CheckNull(true);
            CommandLine.onSubmit.AddListener(OnSubmit_CommandLine);

            Submit.CheckNull(true);
            Submit.onClick.AddListener(OnClick_Submit);

            ToggleActive(false);
            StackTrace.SetActive(false);
        }

        #endregion
    }
}