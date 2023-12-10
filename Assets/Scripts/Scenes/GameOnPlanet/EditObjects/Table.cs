using System.Diagnostics;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GameOnPlanet
{
    public class Table : EditObject
    {
        private void Start()
        {
            Initialise(out UnityEvent action);
            action.AddListener(DoAction);
        }

        private void DoAction()
        {
            if (_isEditing)
            {
                UnityEngine.Debug.Log("aaaaaa");
            }
        }
    }
}
