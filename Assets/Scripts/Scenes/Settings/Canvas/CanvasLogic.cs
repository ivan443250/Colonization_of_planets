using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Settings
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI[] _panelTitles;

        [SerializeField]
        private GameObject[] _panels;

        private GameControlPanel _gameControlPanel;
        private SoundsPanel _soundsPanel;

        private int _currentSelctedPanel;

        public void Initialize()
        {
            _gameControlPanel = _panels[0].GetComponent<GameControlPanel>();

            _soundsPanel = _panels[2].GetComponent<SoundsPanel>();

            _gameControlPanel.Initialize();

            UnpackSaveData();

            for (int i = 0; i < _panels.Length; i++)
            {
                _panels[i].gameObject.SetActive(false);
                _panelTitles[i].color = Color.white;
            }

            _panels[_currentSelctedPanel].gameObject.SetActive(true);
            _panelTitles[_currentSelctedPanel].color = Color.yellow;
        }

        public void OnSelectedPanelChanged(int newSelectedPanel)
        {
            _panels[_currentSelctedPanel].gameObject.SetActive(false);
            _panels[newSelectedPanel].gameObject.SetActive(true);
            _panelTitles[_currentSelctedPanel].color = Color.white;
            _panelTitles[newSelectedPanel].color = Color.yellow;
            _currentSelctedPanel = newSelectedPanel;
        }

        public void ResetToDefaultSettings()
        {
            _gameControlPanel.ResetToDefaultSettings();
            _soundsPanel.ResetToDefaultSettings();
        }

        public void SaveSettingsChanges()
        {
            SaveData _saveData = WrapUpSaveData();

            SaveSystem.Save(_saveData, SaveFilenames.GameSettings);
            SceneManager.LoadScene(0);
        }

        private SaveData WrapUpSaveData()
        {
            List<int>[] _saveDataIntNumbers = new List<int>[1];
            _saveDataIntNumbers[0] = new List<int> { _currentSelctedPanel};

            List<float>[] _saveDataFloatNumbers = new List<float>[1];
            _saveDataFloatNumbers[0] = _soundsPanel.GetSettingsChanges();

            List<string>[] _saveDataLines = new List<string>[1];
            _saveDataLines[0] = _gameControlPanel.GetSettingsChanges();

            return new SaveData(_saveDataIntNumbers, _saveDataFloatNumbers, _saveDataLines);
        }

        private void UnpackSaveData()
        {
            SaveData _saveData = SaveSystem.Load(SaveFilenames.GameSettings);
            if (_saveData != null)
            {
                if (_saveData.IntNumbers != null)
                    _currentSelctedPanel = _saveData.IntNumbers[0][0];
                else
                    _currentSelctedPanel = 0;

                if (_saveData.FloatNumbers != null)
                    _soundsPanel.RecieveSettings(_saveData.FloatNumbers[0]);
                else
                    _soundsPanel.RecieveSettings(null);

                _gameControlPanel.RecieveSettings(_saveData.Lines[0]);
            }
        }
    }
}
