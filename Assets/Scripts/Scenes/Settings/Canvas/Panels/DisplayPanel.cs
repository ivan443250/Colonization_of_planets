using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class DisplayPanel : MonoBehaviour
    {
        [SerializeField]
        private Toggle _synchronizationToggle;
        [SerializeField]
        private Button[] _graphicsButtons;

        private TextMeshProUGUI[] _graphicsButtonTexts;

        private int _selectedGraphicIndex;

        public void Initialize()
        {
            _selectedGraphicIndex = 0;
            _graphicsButtonTexts = new TextMeshProUGUI[_graphicsButtons.Length];
            for (int i = 0;  i < _graphicsButtons.Length; i++)
                _graphicsButtonTexts[i] = _graphicsButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            CorrectUi();
        }

        public void OnGraphicsChanged(int newSelectedGraphicIndex)
        {
            _selectedGraphicIndex = newSelectedGraphicIndex;
            CorrectUi();
        }

        public void RecieveSettings(bool isToggleOn, int selectedGraphicIndex)
        {
            _synchronizationToggle.isOn = isToggleOn;
            _selectedGraphicIndex = selectedGraphicIndex;
            CorrectUi();
        }

        public void GetSettingsChanges(out bool isSynchronizationToggleOn, out int selectedGraphicIndex)
        {
            isSynchronizationToggleOn = _synchronizationToggle.isOn;
            selectedGraphicIndex = _selectedGraphicIndex;
        }

        public void ResetToDefaultSettings()
        {
            _synchronizationToggle.isOn = DefaultSettings.IsSynchronizationToggleOn;
            _selectedGraphicIndex = DefaultSettings.SelectedGraphicIndex;
            CorrectUi();
        }

        private void CorrectUi()
        {
            foreach (var text in _graphicsButtonTexts) 
                text.color = Color.white;
            _graphicsButtonTexts[_selectedGraphicIndex].color = Color.yellow;
        }
    }
}