using UnityEngine;

[CreateAssetMenu(fileName = "WheelData", menuName = "ScriptableObjects/WheelData")]
public class WheelData : ScriptableObject
{
    [SerializeField]
    private Transform _model;
    public Transform Model => _model;

    [SerializeField]
    private float _rotateSpeed;
    public float RotationSpeed => _rotateSpeed;
}
