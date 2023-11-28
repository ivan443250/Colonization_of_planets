using Settings;

public static class DataHolder
{
    private static SettingsData _settingsData;
    public static SettingsData SettingsData
    {
        get
        {
            if (_settingsData == null)
            {
                _settingsData = SaveSystem.Load<SettingsData>(SaveFilenames.GameSettings);

                if (_settingsData == null)
                {
                    _settingsData = new SettingsData();
                }
            }
            return _settingsData;
        }
        set
        {
            SaveSystem.Save(value, SaveFilenames.GameSettings);
            _settingsData = value;
        }
    }


}
