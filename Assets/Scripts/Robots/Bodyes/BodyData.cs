using UnityEngine;
using Robot;

[CreateAssetMenu(fileName = "BodyData", menuName = "ScriptableObjects/BodyData")]
public class BodyData : ScriptableObject
{
    [SerializeField]
    private Transform _nodeModel;
    public Transform NodeModel => _nodeModel;
    [SerializeField]
    private Vector2[] _nodesPositions;
    public Vector2[] NodesPositions => _nodesPositions;
    [SerializeField]
    private Transform _model;
    public Transform Model => _model;

    private int _indexInCollection;
    public int IndexInCollection => _indexInCollection;

    public void SetIndexInCollection(int indexInCollection)
    {
        _indexInCollection = indexInCollection;
    }
}
