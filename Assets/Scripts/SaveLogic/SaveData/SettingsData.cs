using UnityEngine;
using Settings;
using System;

public class SettingsData 
{
    public int CurrentSelctedPanel;
    public KeyCode[] ControlKeys;
    public bool IsSynchronizationToggleOn;
    public int SelectedGraphicIndex;
    public float[] SoundSliderValues;
    private SaveData _saveData;

    public SettingsData()
    {
        Load();
    }

    public void Save()
    {
        if (_saveData == null)
            _saveData = new SaveData();

        _saveData.Bools = new bool[][] { new bool[] { IsSynchronizationToggleOn } };

        _saveData.IntNumbers = new int[][] { new int[] { CurrentSelctedPanel }, new int[] { SelectedGraphicIndex } };

        _saveData.Lines = new string[1][] { new string[ControlKeys.Length] };
        for (int i = 0; i < ControlKeys.Length; i++)
            _saveData.Lines[0][i] = ControlKeys[i].ToString();

        _saveData.FloatNumbers = new float[1][] { new float[SoundSliderValues.Length] };
        for (int i = 0; i < SoundSliderValues.Length; i++)
            _saveData.FloatNumbers[0][i] = SoundSliderValues[i];

        SaveSystem.Save(_saveData, SaveFilenames.GameSettings);
    }

    public void Load()
    {
        if (_saveData != null)
            return;

        _saveData = SaveSystem.Load(SaveFilenames.GameSettings);

        if (_saveData == null)
        {
            CurrentSelctedPanel = DefaultSettings.CurrentSelectedPanel;
            ControlKeys = DefaultSettings.ControlKeys;
            IsSynchronizationToggleOn = DefaultSettings.IsSynchronizationToggleOn;
            SelectedGraphicIndex = DefaultSettings.SelectedGraphicIndex;
            SoundSliderValues = DefaultSettings.SoundsSliders;
            return;
        }

        try
        {
            IsSynchronizationToggleOn = _saveData.Bools[0][0];

            CurrentSelctedPanel = _saveData.IntNumbers[0][0];
            SelectedGraphicIndex = _saveData.IntNumbers[1][0];

            ControlKeys = new KeyCode[_saveData.Lines[0].Length];
            for (int i = 0; i < _saveData.Lines[0].Length; i++)
                ControlKeys[i] = (KeyCode)Enum.Parse(typeof(KeyCode), _saveData.Lines[0][i]);

            SoundSliderValues = new float[_saveData.FloatNumbers[0].Length];
            for (int i = 0; i < _saveData.FloatNumbers[0].Length; i++)
                SoundSliderValues[i] = _saveData.FloatNumbers[0][i];
        }
        catch
        {
            CurrentSelctedPanel = DefaultSettings.CurrentSelectedPanel;
            ControlKeys = DefaultSettings.ControlKeys;
            IsSynchronizationToggleOn = DefaultSettings.IsSynchronizationToggleOn;
            SelectedGraphicIndex = DefaultSettings.SelectedGraphicIndex;
            SoundSliderValues = DefaultSettings.SoundsSliders;
            SaveSystem.Delete(SaveFilenames.GameSettings);
        }
        
    }
}
