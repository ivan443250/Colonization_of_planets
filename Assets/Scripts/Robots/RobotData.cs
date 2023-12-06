using System;
using UnityEngine;

[Serializable]
public class RobotData
{
    public int BodyCollectionIndex { get; private set; }

    public int[,] WheelIndexes { get; private set; }

    public RobotData(int bodyCollectionIndex, int[,] wheelIndexes)
    {
        BodyCollectionIndex = bodyCollectionIndex;
        WheelIndexes = wheelIndexes;
    }
}
