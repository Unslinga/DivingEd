using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{

    [CreateAssetMenu(menuName = "Events/GameEvent", order = 1)]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> Listeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = Listeners.Count - 1; i >= 0; i--)
            {
                Listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            Listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            Listeners.Remove(listener);
        }
    }
}