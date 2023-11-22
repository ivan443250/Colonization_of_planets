using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton;

        public void Initialize()
        {
            _startButton.onClick.AddListener(LoadGameOnPlanet);
        }

        private void LoadGameOnPlanet()
        {
            SceneManager.LoadScene(1);
        }
    }
}