using UnityEngine;

namespace MainRocketMenu
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
