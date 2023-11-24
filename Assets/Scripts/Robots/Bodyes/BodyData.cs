using UnityEngine;
using Robot;

[CreateAssetMenu(fileName = "BodyData", menuName = "ScriptableObjects/BodyData")]
public class BodyData : ScriptableObject
{
    [SerializeField]
    private Node[] _nodes;
    public Node[] Nodes => _nodes;
    [SerializeField]
    private Vector2[] _nodesPositions;
    public Vector2[] NodesPositions => _nodesPositions;
    [SerializeField]
    private Transform _model;
    public Transform Model => _model;
}
