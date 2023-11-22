using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameOnPlanet
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;
        [SerializeField]
        private PlayerController _playerController;
        [SerializeField]
        private Rocket _rocket;

        private void Start()
        {
            _rocket.Initialize(out UnityEvent show, out UnityEvent hide);
            _canvas.Initialize(show, hide);
            _playerController.Initialize();
        }
    }
}
