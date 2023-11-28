using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class GameControlPanel : MonoBehaviour
    {
        public GameControlPanelData GetSettingsChanges => new GameControlPanelData(_controlKeys);

        [SerializeField]
        private TextMeshProUGUI[] _controlTexts;
        [SerializeField]
        private Button[] _controlButtons;
        private TextMeshProUGUI[] _controlButtonsText;
        private KeyCode[] _controlKeys;
        private bool _isChangeButtonKey;
        private int _currentChangeControlKeyIndex;

        public void Initialize()
        {
            _isChangeButtonKey = false;
            _currentChangeControlKeyIndex = 0;
            _controlButtonsText = new TextMeshProUGUI[4];
            for (int i = 0; i < _controlButtons.Length; i++)
                _controlButtonsText[i] = _controlButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        public void RecieveSettings(GameControlPanelData gameControlPanelData)
        {
            _controlKeys = gameControlPanelData.GetControlKeys();
            CorrectUi();
        }

        public void SetButton(int currentChangeControlKeyIndex)
        {
            CorrectUi();
            _currentChangeControlKeyIndex = currentChangeControlKeyIndex;
            _controlButtonsText[_currentChangeControlKeyIndex].text = "¬ведите любую клавишу";
            _controlButtonsText[_currentChangeControlKeyIndex].color = Color.yellow;
            _isChangeButtonKey = true;
        }

        public void ResetToDefaultSettings()
        {
            _controlKeys = DefaultSettings.ControlKeys;
            CorrectUi();
        }

        private void OnGUI()
        {
            Event currentEvent = Event.current;
            if (currentEvent.isKey && _isChangeButtonKey)
            {
                _controlKeys[_currentChangeControlKeyIndex] = currentEvent.keyCode;
                CorrectUi();
                _isChangeButtonKey = false;
            }
            else if (currentEvent.isMouse && _isChangeButtonKey)
            {
                CorrectUi();
                _isChangeButtonKey = false;
            }
        }

        private void CorrectUi()
        {
            for (int i = 0; i < _controlButtons.Length; i++)
            {
                _controlButtonsText[i].text = _controlKeys[i].ToString();
                _controlButtonsText[i].color = Color.white;
            }
        }
    }
}
