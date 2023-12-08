using TMPro;
using UnityEngine;

namespace EditRobotMenuSpace
{
    public class DataPanellogic : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _mainTitle;

        [SerializeField]
        private Transform _modelParent;

        [SerializeField]
        private TextMeshProUGUI _description;

        [SerializeField]
        private float _modelSize;

        private GameObject _model;

        public void UpdateData(string mainTitle, Transform model, string description)
        {
            if (_model != null)
                Destroy(_model);

            _mainTitle.text = mainTitle;

            _model = Instantiate(model, _modelParent, false).gameObject;
            _model.transform.localPosition = Vector3.zero;
            _model.transform.localRotation = Quaternion.identity;
            _model.transform.localScale *= _modelSize;

            _description.text = description;
        }
    }
}
