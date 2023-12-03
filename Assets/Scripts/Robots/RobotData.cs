using System;
using UnityEngine;

[Serializable]
public class RobotData
{
    public int BodyCollectionIndex {  get; private set; }

    public RobotData(int bodyCollectionIndex)
    {
        BodyCollectionIndex = bodyCollectionIndex;
    }
}
