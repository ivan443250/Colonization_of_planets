using System;
using UnityEngine;

[Serializable]
public class GameInRocketData
{
    public int SelectedRobotIndex {  get; private set; }

    public GameInRocketData(int selectedRobotIndex)
    {
        SelectedRobotIndex = selectedRobotIndex;
    }
}
