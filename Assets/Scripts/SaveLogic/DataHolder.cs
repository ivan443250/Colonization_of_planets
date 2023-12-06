using Robot;
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

    private static RobotData[] _robotDatas;
    public static RobotData[] RobotDatas
    {
        get
        {
            if (_robotDatas == null)
            {
                _robotDatas = SaveSystem.Load<RobotData[]>(SaveFilenames.RobotDatas);

                if (_robotDatas == null)
                    _robotDatas = DefaultRobotDatas.Default;
            }
            return _robotDatas;
        }
        set
        {
            SaveSystem.Save<RobotData[]>(value, SaveFilenames.RobotDatas);
            _robotDatas = value;
        }
    }

    private static GameInRocketData _gameInRocketData;
    public static GameInRocketData GameInRocketData 
    {
        get
        {
            if (_gameInRocketData == null)
            {
                _gameInRocketData = SaveSystem.Load<GameInRocketData>(SaveFilenames.GameInRocketData);

                if (_gameInRocketData == null)
                    _gameInRocketData = DefaultGameInRocketData.Default;
            }

            return _gameInRocketData;
        }
        set
        {
            SaveSystem.Save(value, SaveFilenames.GameInRocketData);
            _gameInRocketData = value;
        }
    }
}