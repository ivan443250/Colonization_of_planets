using System;

[Serializable]
public class GameData
{
    public bool IsStartMoveWhatched;
    public bool IsEducationCompleted;

    public GameData(bool isStartMoveWhatched, bool isEducationCompleted)
    {
        IsStartMoveWhatched = isStartMoveWhatched;
        IsEducationCompleted = isEducationCompleted;
    }
}
