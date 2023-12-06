using UnityEngine;

namespace Robot
{
    public class Wheel : AdditionalDetail
    {
        private int _driveDirection;
        private float _rotationSpeed;

        public void Initialize(WheelData wheelData)
        {
            InstanceModel(wheelData.Model);
            _rotationSpeed = wheelData.RotationSpeed;
            _driveDirection = 0;
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
            RotateModel(_rotationSpeed, _driveDirection);
        }
    }
}