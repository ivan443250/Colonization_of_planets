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

        public void Initialize()
        {
            _isChangeButtonKey = false;
            _currentChangeControlKeyIndex = 0;
            _controlButtonsText = new TextMeshProUGUI[4];
            for (int i = 0; i < _controlButtons.Length; i++)
                _controlButtonsText[i] = _controlButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        public void RecieveSettings(List<string> controlKeysInStr)
        {
            if (controlKeysInStr == null)
                ResetToDefaultSettings();
            else
            {
                _controlKeys = ParseSettingsChanges(controlKeysInStr);
                CorrectUi();
            }
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

        public List<string> GetSettingsChanges()
        {
            return new List<string> { _controlKeys[0].ToString(), _controlKeys[1].ToString(), _controlKeys[2].ToString(), _controlKeys[3].ToString() };
        }

        private KeyCode[] ParseSettingsChanges(List<string> str)
        {
            int strCount = str.Count;
            KeyCode[] answer = new KeyCode[strCount];
            for (int i = 0; i < strCount; i++)
                answer[i] = (KeyCode)Enum.Parse(typeof(KeyCode), str[i]);
            return answer;
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
