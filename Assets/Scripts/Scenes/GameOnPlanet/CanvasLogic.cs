using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameOnPlanet
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField] 
        private Button _interactionButton;

        [SerializeField]
        private TextMeshProUGUI _interactionButtonText;

        [SerializeField]
        private GameObject _robotsPanel;

        [SerializeField]
        private GameObject _robotMinerPanel;

        [SerializeField]
        private GameObject _robotCollectorPanel;

        private bool _isSwitchedOn;
        public bool IsDetailsCollected;

        public void CloseRobotMinerPanel()
        {
            _robotMinerPanel.SetActive(false);
        }

        public void OpenRobotMinerPanel()
        {
            _robotMinerPanel.SetActive(true);
            _robotCollectorPanel.SetActive(false);
        }

        public void CloseRobotCollectorPanel()
        {
            _robotCollectorPanel.SetActive(false);
        }

        public void OpenRobotCollectorPanel()
        {
            _robotMinerPanel.SetActive(false);
            _robotCollectorPanel.SetActive(true);
        }

        public void Initialize(UnityEvent On, UnityEvent Off)
        {
            _robotMinerPanel.SetActive(false);
            _robotCollectorPanel.SetActive(false);

            _interactionButton.gameObject.SetActive(false);
            On.AddListener(SwitchOn);
            Off.AddListener(SwitchOff);

            _interactionButton.gameObject.SetActive(false);
            _isSwitchedOn = true;
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void OpenInteractionButton(string text, out UnityEvent onClick)
        {
            onClick = _interactionButton.onClick;

            if (_isSwitchedOn == false)
                return;

            _interactionButton.gameObject.SetActive(true);
            _interactionButtonText.text = text;
        }

        public void CloseInteractionButton()
        {
            _interactionButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            _robotsPanel.SetActive(_isSwitchedOn && IsDetailsCollected);
        }

        private void SwitchOn()
        {
            _isSwitchedOn = true;
        }

        private void SwitchOff()
        {
            _isSwitchedOn = false;
            CloseInteractionButton();
        }
    }
}

