using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BlockHandler _blockHandler;

    private void Invoke()
    {
        _blockHandler.Initialize();
    }

    private void Update()
    {
        
    }
}
