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
using XNode;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        #region Fields & Properties

        public static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Singleton.Create<GameManager>();
                    instance.transform.SetAsFirstSibling();
                }

                return instance;
            }
        }

        [field: SerializeField]
        public Graph Graph { get; set; }

        #endregion

        #region Public Methods

        public static List<T> GetNodesByType<T>() where T : Node
        {
            return Instance.Graph.nodes.Where(n => n.GetType() == typeof(T)).Select(n => (T)n).ToList();
        }

        #endregion

        #region Private Methods

        private void Validate()
        {
            
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            Validate();
        }

        void OnValidate()
        {
            Validate();
        }

        #endregion
    }
}