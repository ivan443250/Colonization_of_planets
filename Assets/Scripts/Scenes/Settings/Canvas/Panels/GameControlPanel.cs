using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class GameControlPanel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI[] _controlTexts;
        [SerializeField]
        private Button[] _controlButtons;
        private TextMeshProUGUI[] _controlButtonsText;
        private KeyCode[] _controlKeys;
        private bool _isChangeButtonKey;
        private int _currentChangeControlKeyIndex;

        public void Initialize(List<string> controlKeysInStr)
        {
            _controlKeys = new KeyCode[4]
            { 
                (KeyCode)Enum.Parse(typeof(KeyCode), controlKeysInStr[0]),
                (KeyCode)Enum.Parse(typeof(KeyCode), controlKeysInStr[1]),
                (KeyCode)Enum.Parse(typeof(KeyCode), controlKeysInStr[2]),
                (KeyCode)Enum.Parse(typeof(KeyCode), controlKeysInStr[3])
            };
            _isChangeButtonKey = false;
            _currentChangeControlKeyIndex = 0;
            _controlButtonsText = new TextMeshProUGUI[4];
            for (int i = 0;  i < _controlButtons.Length; i++)
            {
                _controlButtonsText[i] = _controlButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                _controlButtonsText[i].text = _controlKeys[i].ToString();
            }
        }

        public void Initialize()
        {
            _controlKeys = GameControlPanelDefaultSettings.ControlKeys;
            _isChangeButtonKey = false;
            _currentChangeControlKeyIndex = 0;
            _controlButtonsText = new TextMeshProUGUI[4];
            for (int i = 0; i < _controlButtons.Length; i++)
            {
                _controlButtonsText[i] = _controlButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                _controlButtonsText[i].text = _controlKeys[i].ToString();
            }
        }

        public void SetButton(int currentChangeControlKeyIndex)
        {
            _controlButtonsText[_currentChangeControlKeyIndex].text = _controlKeys[_currentChangeControlKeyIndex].ToString();
            _controlButtonsText[_currentChangeControlKeyIndex].color = Color.white;
            _currentChangeControlKeyIndex = currentChangeControlKeyIndex;
            _controlButtonsText[_currentChangeControlKeyIndex].text = "¬ведите любую клавишу";
            _controlButtonsText[_currentChangeControlKeyIndex].color = Color.yellow;
            _isChangeButtonKey = true;
        }

        public void ResetToDefaultSettings()
        {
            _controlKeys = GameControlPanelDefaultSettings.ControlKeys;
            for (int i = 0; i < _controlButtons.Length; i++)
            {
                _controlButtonsText[i].text = _controlKeys[i].ToString();
            }
        }

        public List<string> GetSettingsChanges()
        {
            return new List<string> { _controlKeys[0].ToString(), _controlKeys[1].ToString(), _controlKeys[2].ToString(), _controlKeys[3].ToString() };
        }

        private void OnGUI()
        {
            Event currentEvent = Event.current;
            if (currentEvent.isKey && _isChangeButtonKey)
            {
                _controlKeys[_currentChangeControlKeyIndex] = currentEvent.keyCode;
                _controlButtonsText[_currentChangeControlKeyIndex].text = currentEvent.keyCode.ToString();
                _controlButtonsText[_currentChangeControlKeyIndex].color = Color.white;
                _isChangeButtonKey = false;
            }
            else if (currentEvent.isMouse && _isChangeButtonKey)
            {
                _controlButtonsText[_currentChangeControlKeyIndex].text = _controlKeys[_currentChangeControlKeyIndex].ToString();
                _controlButtonsText[_currentChangeControlKeyIndex].color = Color.white;
                _isChangeButtonKey = false;
            }
        }

    }
}
