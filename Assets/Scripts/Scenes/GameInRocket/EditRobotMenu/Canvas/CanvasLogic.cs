using UnityEngine;
using UnityEngine.UI;

namespace EditRobotMenuSpace
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private RobotCollections _robotCollections;

        [SerializeField]
        private Button[] _scrollButtons;

        [SerializeField]
        private ScrollViewLogic[] _scrollPanels;

        [SerializeField]
        private DataPanellogic _dataPanellogic;

        private int _selectedScrollPanelIndex;

        public void Initialize()
        {
            _selectedScrollPanelIndex = 0;

            int bodyModelsCount = _robotCollections.BodyDatas.Length;
            Transform[] bodyModels = new Transform[bodyModelsCount];
            for (int i = 0; i < bodyModelsCount; i++)
            {
                bodyModels[i] = _robotCollections.BodyDatas[i].Model;
            }
            _scrollPanels[0].Initialize(bodyModels, _robotCollections, _dataPanellogic, ScrollViewType.Body);

            int wheelModelsCount = _robotCollections.WheelDatas.Length;
            Transform[] wheelModels = new Transform[wheelModelsCount];
            for (int i = 0; i < wheelModelsCount; i++)
            {
                wheelModels[i] = _robotCollections.WheelDatas[i].Model;
            }
            _scrollPanels[1].Initialize(wheelModels, _robotCollections, _dataPanellogic, ScrollViewType.Wheel);

            CorrectSelectedIndex();
        }

        public void ChangeSelectedScrollPanelIndex(int selectedScrollPanelIndex)
        {
            _selectedScrollPanelIndex = selectedScrollPanelIndex;
            CorrectSelectedIndex();
        }

        private void CorrectSelectedIndex()
        {
            foreach (var button in _scrollButtons)
                button.GetComponent<Graphic>().color = Color.white;
            _scrollButtons[_selectedScrollPanelIndex].GetComponent<Graphic>().color = Color.red;

            foreach (var panel  in _scrollPanels)
                panel.gameObject.SetActive(false);
            _scrollPanels[_selectedScrollPanelIndex].gameObject.SetActive(true);
        }
    }
}
