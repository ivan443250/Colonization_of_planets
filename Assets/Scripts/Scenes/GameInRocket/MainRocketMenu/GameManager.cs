using RobotV2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainRocketMenu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;

        [SerializeField]
        private RobotMiner _robotMinerPref;

        [SerializeField]
        private RobotCollector _robotCollectorPref;

        private RobotMiner _robotMiner;
        private RobotCollector _robotCollector;

        private int _selectedRobot;

        public void ChangeSelectedRobot(int changeStep)
        {
            GetRobotByIndex(_selectedRobot).gameObject.SetActive(false);
            _selectedRobot += changeStep;
            GetRobotByIndex(_selectedRobot).gameObject.SetActive(true);
            CorrectRobotButtons();
        }

        public void LoadEditRobotMenu()
        {
            SaveSceneData();
            SceneManager.LoadScene(6);
        }

        private void Start()
        {
            _canvas.Initialize();

            _robotMiner = Instantiate(_robotMinerPref);
            _robotCollector = Instantiate(_robotCollectorPref);

            for (int i = 0; i < 2; i++)
            {
                GetRobotByIndex(i).SetActive(false);
            }
            _selectedRobot = DataHolder.GameInRocketData.SelectedRobotIndex;
            GetRobotByIndex(_selectedRobot).SetActive(true);
            CorrectRobotButtons();
        }

        private void CorrectRobotButtons()
        {
            bool setActiveBackButton;
            bool setActiveNextButton;

            if (_selectedRobot == 0)
                setActiveBackButton = false;
            else
                setActiveBackButton = true;

            if (_selectedRobot == 1)
                setActiveNextButton = false;
            else
                setActiveNextButton = true;

            _canvas.SetActiveRobotButtons(setActiveBackButton, setActiveNextButton);
        }

        private void SaveSceneData()
        {
            DataHolder.GameInRocketData = new GameInRocketData(_selectedRobot);
        }

        private GameObject GetRobotByIndex(int index)
        {
            switch (index)
            {
                case 0: return _robotMiner.gameObject;

                case 1: return _robotCollector.gameObject;

                default: return null;
            }
        }
    }
}
