using UnityEngine;

namespace Robot
{
    public static class DefaultRobotDatas
    {
        public static RobotData[] Default => new RobotData[] 
        { 
            new RobotData
            (0, 
                new int[] {0},
                new int[] {0}
            ),
            new RobotData
            (1,
                new int[] {0, 0},
                new int[] {0, 1}
            ),
            new RobotData
            (2,
                new int[] {0},
                new int[] {0}
            ),
        };
    }
}
