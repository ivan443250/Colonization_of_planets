using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class DisplayPanel : MonoBehaviour
    {
        public DisplayPanelData GetSettingsChanges => new DisplayPanelData(_synchronizationToggle.isOn, _selectedGraphicIndex);

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

        public void RecieveSettings(DisplayPanelData displayPanelData)
        {
            _synchronizationToggle.isOn = displayPanelData._isSynchronizationToggleOn;
            _selectedGraphicIndex = displayPanelData._selectedGraphicIndex;
            CorrectUi();
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