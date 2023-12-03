using Robot;
using UnityEngine;

namespace MainRocketMenu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;

        [SerializeField]
        private RobotFactory _robotFactory;

        private Robot.Robot[] _robots;
        private int _selectedRobot;

        public void ChangeSelectedRobot(int changeStep)
        {
            _robots[_selectedRobot].gameObject.SetActive(false);
            _selectedRobot += changeStep;
            _robots[_selectedRobot].gameObject.SetActive(true);
            CorrectRobotButtons();
        }

        private void Start()
        {
            _canvas.Initialize();
            _robots = _robotFactory.InstanceAllRobots(Vector2.zero);
            foreach (Robot.Robot robot in _robots)
                robot.gameObject.SetActive(false);
            _selectedRobot = DataHolder.GameInRocketData.SelectedRobotIndex;
            _robots[_selectedRobot].gameObject.SetActive(true);
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

            if (_selectedRobot == _robots.Length - 1)
                setActiveNextButton = false;
            else
                setActiveNextButton = true;

            _canvas.SetActiveRobotButtons(setActiveBackButton, setActiveNextButton);
        }
    }
}
