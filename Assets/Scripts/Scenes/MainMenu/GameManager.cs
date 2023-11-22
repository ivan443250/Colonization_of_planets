using UnityEngine;

namespace MainMenu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;

        void Start()
        {
            _canvas.Initialize();
        }
    }
}

