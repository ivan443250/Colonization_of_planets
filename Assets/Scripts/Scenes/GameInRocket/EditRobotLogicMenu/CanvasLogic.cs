using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EditRobotLogicMenuSpace
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Button[] _functions;

        [SerializeField]
        private GameObject[] _actionPanels;

        private int _selectedFunction;

        public void ChangeSelectedFunction(int selectedFunction)
        {
            _selectedFunction = selectedFunction;
            CorrectSelectedFunction();
        }

        public void LoadRocketMenuScene()
        {
            SceneManager.LoadScene(2);
        }

        private void Start()
        {
            _selectedFunction = 0;
            CorrectSelectedFunction();
        }

        private void CorrectSelectedFunction()
        {
            foreach (var func in _functions)
                func.GetComponent<Graphic>().color = Color.white;
            _functions[_selectedFunction].GetComponent<Graphic>().color = Color.red;

            foreach (var panel in _actionPanels)
                panel.SetActive(false);
            _actionPanels[_selectedFunction].SetActive(true);

            _text.text = $"Функция {_selectedFunction + 1}";
        }
    }
}