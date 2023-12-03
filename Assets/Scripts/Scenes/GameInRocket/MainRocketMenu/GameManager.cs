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

        private void Start()
        {
            _canvas.Initialize();
            _robotFactory.InstanceRobot(Vector2.zero);
        }
    }
}
