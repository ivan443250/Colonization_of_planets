using System;
using UnityEngine;

[Serializable]
public class RobotData
{
    public int BodyCollectionIndex { get; private set; }

    public int[] WheelCollectionIndex { get; private set; }
    public int[] WheelNodeIndex { get; private set; }

    public int[] BatteryCollectionIndex { get; private set; }
    public int[] BatteryNodeIndex { get; private set; }

    public int[] VisorCollectionIndex { get; private set; }
    public int[] VisorNodeIndex { get; private set; }

    public int[] MiningToolCollectionIndex { get; private set; }
    public int[] MiningToolNodeIndex { get; private set; }

    public int[] StorageToolCollectionIndex { get; private set; }
    public int[] StorageToolNodeIndex { get; private set; }

    public RobotData(int bodyCollectionIndex, 
        int[] wheelCollectionIndex, int[] wheelNodeIndex,
        int[] batteryCollectionIndex, int[] batteryNodeIndex,
        int[] visorCollectionIndex, int[] visorNodeIndex,
        int[] miningToolCollectionIndex, int[] miningToolNodeIndex,
        int[] storageToolCollectionIndex, int[] storageToolNodeIndex)
    {
        BodyCollectionIndex = bodyCollectionIndex;
        WheelCollectionIndex = wheelCollectionIndex;
        WheelNodeIndex = wheelNodeIndex;
        BatteryCollectionIndex = batteryCollectionIndex;
        BatteryNodeIndex = batteryNodeIndex;
        VisorCollectionIndex = visorCollectionIndex;
        VisorNodeIndex = visorNodeIndex;
        MiningToolCollectionIndex = miningToolCollectionIndex;
        MiningToolNodeIndex = miningToolNodeIndex;
        StorageToolCollectionIndex = storageToolCollectionIndex;
        StorageToolNodeIndex = storageToolNodeIndex;
    }
}
