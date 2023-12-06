using UnityEngine;

namespace Robot
{
    public class Body : MonoBehaviour
    {
        private Transform _model;

        private Node[] _nodes;

        private Wheel[] _wheels;

        public void Initialize(BodyData bodyData)
        {
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
        }
    }
}
