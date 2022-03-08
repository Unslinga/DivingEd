// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class JSONObject
    {
        #region Fields & Properties

        public string ObjectName { get; set; }

        private string uuid = Guid.NewGuid().ToString();
        public string UUID { get { return uuid; } }

        public List<JSONObject> Children { get; private set; } = new List<JSONObject>();
        public JSONObject this[int index] { get { return Children[index]; } }
        public List<JSONObject> this[string name] { get { return Children.Where(j => j.ObjectName == name).ToList(); } }

        #endregion

        public JSONObject(string objectName)
        {
            ObjectName = objectName;
        }

        #region Public Methods



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

    public class JSONObject<T> : JSONObject
    {
        public JSONObject(string objectName, T objectValue) : base(objectName)
        {
            ObjectValue = objectValue;
        }

        public T ObjectValue { get; set; } = default(T);
        public string ValueType { get { return typeof(T).Name; } }
    }
}