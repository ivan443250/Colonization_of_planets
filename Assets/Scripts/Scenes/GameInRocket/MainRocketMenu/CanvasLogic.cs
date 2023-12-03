using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainRocketMenu
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _backRobotButton;

        [SerializeField]
        private Button _nextRobotButton;

        public void Initialize()
        {
            _backButton.onClick.AddListener(LoadGameOnPlanet);
        }

        public void SetActiveRobotButtons(bool setActiveBackButton, bool setActiveNextButton)
        {
            _backRobotButton.gameObject.SetActive(setActiveBackButton);
            _nextRobotButton.gameObject.SetActive(setActiveNextButton);
        }

        private void LoadGameOnPlanet()
        {
            SceneManager.LoadScene(1);
        }
    }
}

