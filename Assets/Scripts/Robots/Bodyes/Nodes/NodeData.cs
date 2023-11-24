using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NodeData", menuName = "ScriptableObjects/NodeData")]
public class NodeData : ScriptableObject
{
    [SerializeField]
    private Transform _model;
    public Transform Model => _model;
}
