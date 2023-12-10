using System;

[Serializable]
public class GameData
{
    public bool IsStartMoveWhatched;
    public bool[] EducationDialogsIndexes;

    public GameData(bool isStartMoveWhatched, bool[] educationDialogsIndexes)
    {
        IsStartMoveWhatched = isStartMoveWhatched;
        EducationDialogsIndexes = educationDialogsIndexes;
    }
}
