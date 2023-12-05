using UnityEngine;

namespace Robot
{
    public class RobotFactory : MonoBehaviour
    {
        [SerializeField]
        private RobotCollections _robotCollections;

        public Robot InstanceRobot(int robotDataIndex, Vector2 position)
        {
            Robot robot = new GameObject().AddComponent<Robot>();
            robot.transform.position = position;
            robot.Initialize(_robotCollections.BodyDatas[DataHolder.RobotDatas[robotDataIndex].BodyCollectionIndex]);
            return robot;
        }

        public Robot[] InstanceAllRobots(Vector2 position)
        {
            int robotsCount = DataHolder.RobotDatas.Length;
            Robot[] robots = new Robot[robotsCount];

            for (int i = 0; i < robotsCount; i++)
                robots[i] = InstanceRobot(i, position);

            return robots;
        }
    }
}
