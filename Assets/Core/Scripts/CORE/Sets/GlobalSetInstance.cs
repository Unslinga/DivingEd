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
using UnityEngine;

namespace Core
{
    public class GlobalSetInstance : MonoBehaviour, IInstance
    {
        #region Fields

        private static GlobalSetInstance instance;

        #endregion

        #region Properties

        public static GlobalSetInstance Instance 
        { 
            get 
            { 
                if (instance == null)
                {
                    instance = Instantiate();
                }
                return instance; 
            }
            private set
            {
                instance = value;
            }
        }

        public List<ISet> SetList { get; set; } = new List<ISet>();

        public ISet this[string name]
        {
            get
            {
                return SetList.FirstOrDefault(s => s.Name == name);
            }
        }

        #endregion

        #region Public Methods

        public static void Register(ISet set)
        {
            if (!Instance.SetList.Contains(set))
            {
                Instance.SetList.Add(set);
            }
        }

        #endregion

        #region Private Methods

        private static GlobalSetInstance Instantiate()
        {
            GameObject gameObject = new GameObject(nameof(GlobalSetInstance));

            var instance = gameObject.GetInstance<GlobalSetInstance>() as GlobalSetInstance;

            if (instance != null)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    DestroyImmediate(gameObject);
                };
#else
                Destroy(gameObject);
#endif
                return instance;
            }

            return gameObject.AddComponent<GlobalSetInstance>();
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            this.Instance<GlobalSetInstance>();
        }

        #endregion
    }
}