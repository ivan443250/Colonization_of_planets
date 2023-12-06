using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCellsSpace
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _panels;

        private int _selectedIndex;

        private void Start()
        {
            _selectedIndex = 0;
            foreach (var panel in _panels)
                panel.SetActive(false);
            _panels[_selectedIndex].SetActive(true);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                if (_selectedIndex == 6)
                {
                    SceneManager.LoadScene(1);
                    return;
                }
                _panels[_selectedIndex].SetActive(false);
                _selectedIndex++;
                _panels[_selectedIndex].SetActive(true);
            }
        }
    }
}