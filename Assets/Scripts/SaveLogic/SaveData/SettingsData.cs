using UnityEngine;
using System;

namespace Settings
{
    [Serializable]
    public class SettingsData 
    {
        public int CurrentSelctedPanel { get; private set; }
        public GameControlPanelData GameControlPanelDt { get; private set; }
        public DisplayPanelData DisplayPanelDt { get; private set; }
        public SoundsPanelData SoundsPanelDt { get; private set; }

        public SettingsData() 
        {
            CurrentSelctedPanel = DefaultSettings.CurrentSelectedPanel;
            GameControlPanelDt = new GameControlPanelData(DefaultSettings.ControlKeys);
            DisplayPanelDt = new DisplayPanelData(DefaultSettings.IsSynchronizationToggleOn, DefaultSettings.SelectedGraphicIndex);
            SoundsPanelDt = new SoundsPanelData(DefaultSettings.SoundsSlidersValues);
        }

        public SettingsData(int currentSelctedPanel, GameControlPanelData gameControlPanelDt, DisplayPanelData displayPanelDt, SoundsPanelData soundsPanelDt)
        {
            CurrentSelctedPanel = currentSelctedPanel;
            GameControlPanelDt = gameControlPanelDt;
            DisplayPanelDt = displayPanelDt;
            SoundsPanelDt = soundsPanelDt;
        }
    }

    [Serializable]
    public class GameControlPanelData
    {
        private KeyCode[] _controlKeys;

        public GameControlPanelData(KeyCode[] controlKeys)
        {
            _controlKeys = controlKeys;
        }

        public KeyCode[] GetControlKeys()
        {
            KeyCode[] controlKeys = new KeyCode[_controlKeys.Length];
            _controlKeys.CopyTo(controlKeys, 0);
            return controlKeys;
        }
    }

    [Serializable]
    public class DisplayPanelData
    {
        public bool _isSynchronizationToggleOn { get; private set; }
        public int _selectedGraphicIndex { get; private set; }

        public DisplayPanelData(bool isSynchronizationToggleOn, int selectedGraphicIndex)
        {
            _isSynchronizationToggleOn = isSynchronizationToggleOn;
            _selectedGraphicIndex = selectedGraphicIndex;
        }
    }

    [Serializable]
    public class SoundsPanelData
    {
        public float[] SoundSliderValues { get; private set; }

        public SoundsPanelData(float[] soundSliderValues)
        {
            SoundSliderValues = soundSliderValues;
        }
    }
}
