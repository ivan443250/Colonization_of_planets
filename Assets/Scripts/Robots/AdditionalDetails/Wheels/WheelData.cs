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

    private int _indexInCollection;
    public int IndexInCollection => _indexInCollection;

    public void SetIndexInCollection(int indexInCollection)
    {
        _indexInCollection = indexInCollection;
    }
}
