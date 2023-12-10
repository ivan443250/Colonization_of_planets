using Unity.Collections;
using UnityEngine;

public class RobotCollections : ScriptableObject
{
    [SerializeField]
    private BodyData[] _bodyDatas;
    public BodyData[] BodyDatas => _bodyDatas;

    [SerializeField]
    private WheelData[] _wheelDatas;
    public WheelData[] WheelDatas => _wheelDatas;

    public void SetIndexesInCollections()
    {
        for (int i = 0;  i < _bodyDatas.Length; i++)
            _bodyDatas[i].SetIndexInCollection(i);

        for (int i = 0; i < _wheelDatas.Length; i++)
            _wheelDatas[i].SetIndexInCollection(i);
    }
}
