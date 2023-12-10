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

        private bool _isSwitchedOn;

        public void Initialize(UnityEvent On, UnityEvent Off)
        {
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
            if (_interactionButton.gameObject.activeInHierarchy == true)
                _interactionButton.gameObject.SetActive(false);
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

