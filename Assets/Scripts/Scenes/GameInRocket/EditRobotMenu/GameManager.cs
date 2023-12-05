using Robot;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EditRobotMenuSpace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;

        [SerializeField]
        private RobotFactory _robotFactory;

        public void LoadMainRocketMenuScene()
        {
            SceneManager.LoadScene(2);
        }

        private void Start()
        {
            _robotFactory.InstanceRobot(DataHolder.GameInRocketData.SelectedRobotIndex, Vector2.zero);
        }


    }
}