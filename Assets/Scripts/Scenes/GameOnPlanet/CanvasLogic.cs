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

        public void Initialize(UnityEvent On, UnityEvent Off)
        {
            _interactionButton.gameObject.SetActive(false);
            On.AddListener(SwitchOn);
            Off.AddListener(SwitchOff);
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void ChangeInteractionButton(bool setActive, string text, out UnityEvent onClick)
        {
            _interactionButton.gameObject.SetActive(setActive);
            _interactionButtonText.text = text;
            onClick = _interactionButton.onClick;
        }

        private void SwitchOn()
        {
            _interactionButton.gameObject.SetActive(true);
        }

        private void SwitchOff()
        {
            _interactionButton.gameObject.SetActive(false);
        }
    }
}

