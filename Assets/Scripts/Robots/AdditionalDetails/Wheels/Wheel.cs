using UnityEngine;

namespace Robot
{
    public class Wheel : AdditionalDetail
    {
        private int _driveDirection;
        private float _rotationSpeed;

        public void Initialize(WheelData wheelData, int nodeIndex)
        {
            InstanceModel(wheelData.Model);
            _rotationSpeed = wheelData.RotationSpeed;
            _driveDirection = 0;
            _nodeIndex = nodeIndex;
        }

        public void Drive(int driveDirection)
        {
            _driveDirection = driveDirection;
        }

        public void Stop()
        {
            _driveDirection = 0;
        }

        private void FixedUpdate()
        {
            if (_driveDirection == 0)
                return;

            RotateModel(_rotationSpeed, _driveDirection);
        }
    }
}