using UnityEngine;

namespace Robot
{
    public class Body : MonoBehaviour
    {
        private BodyData _bodyData;
        private Transform _model;

        private Node[] _nodes;

        public void Initialize(BodyData bodyData)
        {
            _bodyData = bodyData;

            _model = Instantiate(_bodyData.Model, transform, false);
            _model.localPosition = Vector3.zero;
            _model.localRotation = Quaternion.identity;

            int nodesCount = _bodyData.NodesPositions.Length;
            _nodes = new Node[nodesCount];
            for (int i = 0;  i < nodesCount; i++)
            {
                _nodes[i] = new GameObject().AddComponent<Node>();
                _nodes[i].transform.parent = transform;
                _nodes[i].transform.localPosition = _bodyData.NodesPositions[i];
                _nodes[i].transform.localRotation = Quaternion.identity;
                _nodes[i].Initialize(_bodyData.NodeModel);
            }

        }
    }
}
