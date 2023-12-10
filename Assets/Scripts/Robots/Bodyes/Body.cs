using UnityEngine;

namespace Robot
{
    public class Body : MonoBehaviour
    {
        private Transform _model;

        private Node[] _nodes;

        private Wheel[] _wheels;

        private Battery[] _batteries;

        private Visor[] _visors;

        private MiningTool[] _miningTools;

        private StorageTool[] _storageTools;

        public void Initialize(RobotData robotData, RobotCollections robotCollections)
        {
            BodyData bodyData = robotCollections.BodyDatas[robotData.BodyCollectionIndex];

            _model = Instantiate(bodyData.Model, transform, false);
            _model.localPosition = Vector3.zero;
            _model.localRotation = Quaternion.identity;

            int nodesCount = bodyData.NodesPositions.Length;
            _nodes = new Node[nodesCount];
            for (int i = 0;  i < nodesCount; i++)
            {
                _nodes[i] = new GameObject().AddComponent<Node>();
                _nodes[i].transform.parent = transform;
                _nodes[i].transform.localPosition = bodyData.NodesPositions[i];
                _nodes[i].transform.localRotation = Quaternion.identity;
                _nodes[i].Initialize(bodyData.NodeModel);
            }

            if (robotData.WheelCollectionIndex != null)
            {
                int wheelsCount = robotData.WheelCollectionIndex.GetLength(0);
                if (wheelsCount > 0)
                {
                    _wheels = new Wheel[wheelsCount];
                    for (int i = 0; i < wheelsCount; i++)
                    {
                        _wheels[i] = new GameObject().AddComponent<Wheel>();
                        _wheels[i].transform.parent = _nodes[robotData.WheelNodeIndex[i]].transform;
                        _wheels[i].transform.localPosition = Vector2.zero;
                        _wheels[i].transform.localRotation = Quaternion.identity;
                        _wheels[i].Initialize(robotCollections.WheelDatas[robotData.WheelCollectionIndex[i]], robotData.WheelNodeIndex[i]);
                    }
                }
            }
            
        }

        public void SaveData(RobotData saveData)
        {
            saveData
        }
    }
}
