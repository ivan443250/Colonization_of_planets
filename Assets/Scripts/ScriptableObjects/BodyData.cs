using UnityEngine;

[CreateAssetMenu(fileName = "BodyData", menuName = "ScriptableObjects/BodyData")]
public class BodyData : ScriptableObject
{
    [SerializeField]
    private Vector2[] _nodesPosition;
    public Vector2[] NodesPosition => _nodesPosition;
    [SerializeField]
    private Transform _model;
    public Transform Model => _model;
}
