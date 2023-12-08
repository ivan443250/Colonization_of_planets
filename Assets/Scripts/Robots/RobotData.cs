using System;
using UnityEngine;

[Serializable]
public class RobotData
{
    public int BodyCollectionIndex { get; private set; }

    public int[] WheelCollectionIndex { get; private set; }
    public int[] WheelNodeIndex { get; private set; }

    public RobotData(int bodyCollectionIndex, int[] wheelCollectionIndex, int[] wheelNodeIndex)
    {
        BodyCollectionIndex = bodyCollectionIndex;
        WheelCollectionIndex = wheelCollectionIndex;
        WheelNodeIndex = wheelNodeIndex;
    }
}
