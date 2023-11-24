using UnityEngine;

namespace Robot
{
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private NodeData _nodeData;

        public void Initialize(out Transform initNodeModel)
        {
            initNodeModel = Instantiate(_nodeData.Model);
        }
    }
}
