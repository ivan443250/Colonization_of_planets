using UnityEngine;
using UnityEngine.UI;

namespace EditRobotMenuSpace
{
    public class ScrollViewLogic : MonoBehaviour
    {
        [SerializeField]
        private Button[] _buttons;

        [SerializeField]
        private float _modelsSize;

        private Transform[] _instanceModels;

        public void Initialize(Transform[] models)
        {
            _instanceModels = new Transform[_buttons.Length];
            for (int i = 0; i < _buttons.Length; i++)
            {
                _instanceModels[i] = Instantiate(models[i], _buttons[i].transform, false);
                _instanceModels[i].localPosition = Vector3.zero;
                _instanceModels[i].localRotation = Quaternion.identity;
                _instanceModels[i].localScale *= _modelsSize;
            }
        }
    }
}
