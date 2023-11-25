using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI[] _panelTitles;
        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private GameObject[] _panels;

        private const string _saveFileName = "GameSettings";

        private int _lastTimeSelectedPanel;
        private int _currentSelctedPanel;

        public void Initialize()
        {
            _lastTimeSelectedPanel = 0;
            _panels[0].GetComponent<GameControlPanel>().Initialize(new KeyCode[4] { KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.LeftShift });
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
    }
}
