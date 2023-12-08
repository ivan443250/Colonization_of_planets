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
        private RobotCollections _robotCollections;
        private int _selectedButtonIndex;
        private DataPanellogic _dataPanellogic;
        private ScrollViewType _scrollType;
        private bool _isInitialized = false;

        public void Initialize(Transform[] models, RobotCollections robotCollections, DataPanellogic dataPanellogic, ScrollViewType scrollType)
        {
            _scrollType = scrollType;
            _dataPanellogic = dataPanellogic;
            _selectedButtonIndex = 0;
            _robotCollections = robotCollections;
            _instanceModels = new Transform[_buttons.Length];
            for (int i = 0; i < _buttons.Length; i++)
            {
                _instanceModels[i] = Instantiate(models[i], _buttons[i].transform, false);
                _instanceModels[i].localPosition = Vector3.zero;
                _instanceModels[i].localRotation = Quaternion.identity;
                _instanceModels[i].localScale *= _modelsSize;
            }
            CorrectSelectedButton();
            _isInitialized = true;
        }

        public void ChangeEditedDetail(int buttonIndex)
        {
            _selectedButtonIndex = buttonIndex;
            CorrectSelectedButton();
        }

        private void OnEnable()
        {   
            if (_isInitialized)
                CorrectSelectedButton();
        }

        private void CorrectSelectedButton()
        {
            foreach (var button in _buttons)
                button.GetComponent<Graphic>().color = Color.white;
            _buttons[_selectedButtonIndex].GetComponent<Graphic>().color = Color.red;

            string mainTitle = null;
            Transform model = null;
            string description = null;

            switch (_scrollType)
            {
                case ScrollViewType.Body:
                    mainTitle = _robotCollections.BodyDatas[_selectedButtonIndex].Name;
                    model = _robotCollections.BodyDatas[_selectedButtonIndex].Model;
                    description = _robotCollections.BodyDatas[_selectedButtonIndex].Description;
                    break;

                case ScrollViewType.Wheel:
                    mainTitle = _robotCollections.WheelDatas[_selectedButtonIndex].Name;
                    model = _robotCollections.WheelDatas[_selectedButtonIndex].Model;
                    description = _robotCollections.WheelDatas[_selectedButtonIndex].Description;
                    break;
            }

            _dataPanellogic.UpdateData(mainTitle, model, description);
        }
    }

    public enum ScrollViewType
    {
        Body,
        Wheel
    }
}
