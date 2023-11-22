using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainRocketMenu
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private Button _backButton;

        public void Initialize()
        {
            _backButton.onClick.AddListener(LoadGameOnPlanet);
        }

        private void LoadGameOnPlanet()
        {
            SceneManager.LoadScene(1);
        }
    }
}

