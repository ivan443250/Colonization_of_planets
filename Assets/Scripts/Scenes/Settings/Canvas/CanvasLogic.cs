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

        private const string _saveFileName = "GameSettings";

        private int _lastTimeSelectedPanel;
        private int _currentSelctedPanel;

        public void Initialize()
        {
            SaveData _saveData = SaveSystem.Load("GameSettings");
            if (_saveData == null )
            {
                _panels[0].GetComponent<GameControlPanel>().Initialize();
            }
            else
            {
                _panels[0].GetComponent<GameControlPanel>().Initialize(_saveData.Lines);
            }

            _lastTimeSelectedPanel = 0;

            for (int i = 1; i < _panels.Length; i++)
            {
                _panels[i].gameObject.SetActive(false);
                _panelTitles[i].color = Color.white;
            }
            _panels[_lastTimeSelectedPanel].gameObject.SetActive(true);
            _panelTitles[_lastTimeSelectedPanel].color = Color.yellow;
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
            _panels[0].GetComponent<GameControlPanel>().ResetToDefaultSettings();
        }

        public void SaveSettingsChanges()
        {
            SaveData _saveData = new SaveData(_panels[0].GetComponent<GameControlPanel>().GetSettingsChanges());
            SaveSystem.Save(_saveData, _saveFileName);
            SceneManager.LoadScene(0);
        }
    }
}
