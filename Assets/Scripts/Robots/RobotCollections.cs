using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "RobotCollections", menuName = "ScriptableObjects/RobotCollections")]
public class RobotCollections : ScriptableObject
{
    [SerializeField]
    private BodyData[] _bodyDatas;
    public BodyData[] BodyDatas => _bodyDatas;

    public void SetIndexesInCollections()
    {
        for (int i = 0;  i < _bodyDatas.Length; i++)
            _bodyDatas[i].SetIndexInCollection(i);


    }
}
