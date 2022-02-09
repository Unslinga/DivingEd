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
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Console
{
    public class ConsoleUIElements : MonoBehaviour
    {
        #region Fields

        [ReadOnlyField]
        [SerializeField]
        private bool consoleEnabled;

        private VisualElement consoleDocument;

        private VisualElement commandLine;
        private TextField commandLineInput;

        private Button closeButton;

        private FocusController focusController;

        private VisualElement root;

        private VisualElement stackTrace;

        private Button submitButton;

        #endregion

        #region Properties

        [field: SerializeField]
        public StyleSet Styles { get; private set; }

        public VisualElement CommandLine
        {
            get
            {
                if (commandLine == null)
                {
                    commandLine = Root.Q<VisualElement>("ConsoleCommandLine");
                }
                return commandLine;
            }
        }

        public TextField CommandLineInput
        {
            get
            {
                if (commandLineInput == null)
                {
                    commandLineInput = CommandLine.Q<TextField>("CommandLineInput");
                }
                return commandLineInput;
            }
        }

        public VisualElement ConsoleDocument
        {
            get
            {
                if (consoleDocument == null)
                {
                    consoleDocument = Root.Q<TextField>("Console");
                }
                return consoleDocument;
            }
        }

        public FocusController FocusController
        {
            get
            {
                if (focusController == null)
                {
                    focusController = Root.focusController;
                }
                return focusController;
            }
        }

        public VisualElement Root
        {
            get
            {
                if (root == null)
                {
                    root = GetComponent<UIDocument>().rootVisualElement;
                }
                return root;
            }
        }

        #endregion

        #region Public Methods

        public void CommandLineFocus(bool focused)
        {
            Debug.Log($"CommandLineFocus {focused}");


            CommandLineInput.value = "";

            CommandLine.styleSheets.Clear();
            CommandLine.styleSheets.Add(Styles["TextActive"]);
        }

        public void CommandLineUnfocus()
        {
            Debug.Log("CommandLineUnfocus");

            CommandLine.styleSheets.Clear();
            CommandLine.styleSheets.Add(Styles["TextInactive"]);

            CommandLineInput.value = "Enter Command...";
        }

        public void ToggleConsoleWindowEnabled()
        {
            Debug.Log("ToggleConsoleWindowEnabled");

            consoleEnabled = !consoleEnabled;

            ConsoleDocument.SetEnabled(consoleEnabled);
            
        }

        #endregion

        #region Private Methods

        private void CommandLineChange(string value)
        {
            Debug.Log("CommandLineChange");
        }

        private void CommandLineEnter(bool enter)
        {
            if (enter)
                Debug.Log("CommandLineEnter");
        }

        #endregion

        #region Unity Methods

        void Awake()
        {

            //consoleEnabled = ConsoleDocument.enabled;

            //CloseButton = root.Q<Button>("Close");
            //CloseButton.RegisterCallback<ClickEvent>(ev => ToggleConsoleWindowEnabled());


            CommandLineInput.RegisterCallback<ChangeEvent<string>>(ev => CommandLineChange(ev.newValue));
            CommandLineInput.RegisterCallback<KeyDownEvent>(ev => CommandLineEnter(ev.keyCode == KeyCode.Return || ev.keyCode == KeyCode.KeypadEnter));
            CommandLineInput.RegisterCallback<FocusEvent>(ev => CommandLineFocus(true));
            CommandLineInput.RegisterCallback<FocusOutEvent>(ev => CommandLineFocus(false));
        }

        void Update()
        {
        
        }

        #endregion
    }
}