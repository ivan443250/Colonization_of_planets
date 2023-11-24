using UnityEngine;

namespace Robot
{
    public class Body : MonoBehaviour
    {
        [SerializeField]
        private BodyData _bodyData;

        public void Initialize(out Transform initBodyModel)
        {
            initBodyModel = Instantiate(_bodyData.Model);
            //for (int i = 0; i < _bodyData.Nodes.Length; i++)
            //{
            //    _bodyData.Nodes[i].Initialize(out Transform initNodeModel);
            //    initNodeModel.SetParent(transform);
            //    initNodeModel.localPosition = _bodyData.NodesPositions[i];
            //    initNodeModel.rotation = Quaternion.identity;
            //}
        }
    }
}
