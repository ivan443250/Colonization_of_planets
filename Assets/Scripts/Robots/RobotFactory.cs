using UnityEngine;

namespace Robot
{
    public class RobotFactory : MonoBehaviour
    {
        [SerializeField]
        private RobotCollections _robotCollections;

        public void InstanceRobot(Vector2 position)
        {
            Robot robot = new GameObject().AddComponent<Robot>();
            robot.transform.position = position;
            robot.Initialize(_robotCollections.BodyDatas[0]);
        }
    }
}
