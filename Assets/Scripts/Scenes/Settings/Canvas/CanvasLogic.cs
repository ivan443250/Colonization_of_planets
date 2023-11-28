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
        private DisplayPanel _displayPanel;
        private SoundsPanel _soundsPanel;

        private int _currentSelctedPanel;

        public void Initialize()
        {
            _gameControlPanel = _panels[0].GetComponent<GameControlPanel>();
            _displayPanel = _panels[1].GetComponent<DisplayPanel>();
            _soundsPanel = _panels[2].GetComponent<SoundsPanel>();

            _gameControlPanel.Initialize();
            _displayPanel.Initialize();

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
            _displayPanel.ResetToDefaultSettings();
            _soundsPanel.ResetToDefaultSettings();
        }

        public void SaveSettingsChanges()
        {
            WrapUpSaveData();
            SceneManager.LoadScene(0);
        }

        private void WrapUpSaveData()
        {
            DataHolder.SettingsData = new SettingsData
            (
                _currentSelctedPanel,
                _gameControlPanel.GetSettingsChanges,
                _displayPanel.GetSettingsChanges,
                _soundsPanel.GetSettingsChanges
            );
        }

        private void UnpackSaveData()
        {
            SettingsData _settingsData = DataHolder.SettingsData;

            _currentSelctedPanel = _settingsData.CurrentSelctedPanel;

            _gameControlPanel.RecieveSettings(_settingsData.GameControlPanelDt);
            _displayPanel.RecieveSettings(_settingsData.DisplayPanelDt);
            _soundsPanel.RecieveSettings(_settingsData.SoundsPanelDt);
        }
    }
}
