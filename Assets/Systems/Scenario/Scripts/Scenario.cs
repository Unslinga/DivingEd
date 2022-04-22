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
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Scenario
{
    public class Scenario : MonoBehaviour
    {
        #region Fields & Properties

        [field: Header("File Settings")]

        [field: SerializeField]
        public StringReference Directory { get; set; }

        [field: SerializeField]
        public StringReference FileName { get; set; }

        private string path;
        private bool validPath = false;

        [field: SerializeField]
        public bool LoadFile { get; set; } = false;

        [field: SerializeField]
        public bool SaveFile { get; set; } = true;

        [field: Header("Graph Settings")]

        [field: SerializeField]
        public Vector3Reference GraphPosition { get; set; }

        [field: SerializeField]
        public int XDistance { get; set; }

        [field: SerializeField]
        public int YDistance { get; set; }

        [field: Header("Timer Settings")]

        [field: SerializeField]
        [field: ReadOnlyField]
        public int Frame { get; set; } = 0;
        private bool run = false;

        [field: Header("TimeNode Settings")]

        [field: SerializeField]
        public List<TimelineNode> TimelineNodes { get; set; }

        #endregion

        #region Public Methods

        public void LoadStaticNodes()
        {            
            GameManager.GetNodesByType<TimelineNode>().ForEach(node => TimelineNodes.Add(node));
        }

        public void LoadScenario()
        {
            if (!validPath || !File.Exists(path))
            {
                Debug.LogError("Scenario load file does not exist!");
                return;
            }

            var file = File.ReadAllText(path).Base64Decode();

            Debug.Log(file);

            if (!file.Contains(FileName))
            {
                Debug.LogError($"File: [{FileName.Value}] does not contain valid Scenario!");
                return;
            }

            var lines = file.Split('\n').ToList().Where(l => !string.IsNullOrWhiteSpace(l));


            foreach (var nodeValue in lines.Skip(1))
            {
                Debug.Log(nodeValue);
            }
        }

        public void Restart()
        {
            Frame = 0;
        }

        public void SaveScenario()
        {
            if (!validPath)
            {
                Debug.LogError("Scenario save file is not configured!");
            }

            StringBuilder file = new StringBuilder();

            file.AppendLine($"{FileName.Value}:{TimelineNodes.Count}");

            foreach (var node in TimelineNodes)
            {
                file.AppendLine(node.GetValues());
            }

            File.WriteAllText(path, file.ToString().Replace("Item", "").Base64Encode());
        }

        public void Play()
        {
            run = true;
        }

        public void Pause()
        {
            run = false;
        }

        #endregion

        #region Private Methods

        private void Validate()
        {
            try
            {
                path = Path.GetFullPath(Path.Combine(Directory, FileName));
                validPath = true;
            }
            catch (Exception)
            {
                Debug.LogError("Scenario: Path is not a valid path.");
                validPath = false;
            }
        }

        #endregion

        #region Unity Methods

        void FixedUpdate()
        {
            if (run) Frame++;
        }

        void OnApplicationQuit()
        {
            if (SaveFile) SaveScenario();
        }

        void OnValidate()
        {
            Validate();
        }

        void Start()
        {
            Validate();

            TimelineNodes = new List<TimelineNode>();
            
            if (LoadFile) LoadScenario();
            else LoadStaticNodes();
        }

        #endregion
    }
}