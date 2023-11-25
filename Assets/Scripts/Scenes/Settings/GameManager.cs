using UnityEngine;

namespace Settings
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;

        private void Start()
        {
            _canvas.Initialize();
        }
    }
}
