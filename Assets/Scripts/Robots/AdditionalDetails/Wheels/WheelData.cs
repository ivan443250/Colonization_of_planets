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

    [SerializeField]
    private string _name;
    public string Name => _name;

    [SerializeField]
    private string _description;
    public string Description => _description;

    private int _indexInCollection;
    public int IndexInCollection => _indexInCollection;

    public void SetIndexInCollection(int indexInCollection)
    {
        _indexInCollection = indexInCollection;
    }
}
