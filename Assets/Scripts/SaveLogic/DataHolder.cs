public static class DataHolder
{
    private static SettingsData _settingsData;
    public static SettingsData SettingsData
    {
        get
        {
            if (_settingsData == null)
                _settingsData = new SettingsData();
            return _settingsData;
        }
        set
        {
            _settingsData = value;
            _settingsData.Save();
        }
    }
}
