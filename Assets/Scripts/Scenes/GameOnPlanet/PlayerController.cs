using System;
using UnityEngine;
using Settings;
using UnityEngine.Events;
using RobotV2;

namespace GameOnPlanet
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _maxSpeed;
        [SerializeField, Range(0f, 2f)]
        private float _currentSpeedChange;
        [SerializeField, Range(0f, 1f)]
        private float _defaultSpeedChange;
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private float _groundCheckRadius;
        [SerializeField]
        private int _maxAdditionalJumps;
        [SerializeField]
        private Transform _groundCheckPoint;
        [SerializeField]
        private LayerMask _ground;

        [SerializeField]
        private RobotMiner _robotMinerPref;
        [SerializeField]
        private RobotCollector _robotCollectorPref;
        [SerializeField]
        private Transform _blocks;

        private RobotMiner _robotMiner;
        private RobotCollector _robotCollector;

        private UnityEvent _minerStartAction;
        private UnityEvent _minerStopAction;

        private int _currentAdditionalJumps;
        private float _horisontalInput;

        private bool _isTurnedRight;
        private bool _isMainJumpStay;
        private bool _isCanRun;

        private Rigidbody2D _rigidBody;
        private Animator _animator;

        private KeyCode _leftKey;
        private KeyCode _rightKey;
        private KeyCode _jumpKey;
        private KeyCode _runKey;

        public void MinerStartAction()
        {
            _minerStartAction.Invoke();
        }

        public void MinerStopAction() 
        {
            _minerStopAction.Invoke();
        }

        public void InstanceRobotMiner()
        {
            if (_robotMiner == null)
            {
                if (IsGrounded() == false)
                    return;

                _minerStartAction = new UnityEvent();
                _minerStopAction = new UnityEvent();

                _robotMiner = Instantiate(_robotMinerPref);
                _robotMiner.transform.position = transform.position;
                _robotMiner.transform.rotation = Quaternion.identity;
                _robotMiner.Initialize(_minerStartAction, _minerStopAction, _blocks);
            }
            else
            {
                Destroy(_robotMiner.gameObject);
            }
        }

        public void InstanceRobotCollector()
        {
            if (_robotCollector == null)
            {
                if (IsGrounded() == false)
                    return;

                _robotCollector = Instantiate(_robotCollectorPref);
                _robotCollector.transform.position = transform.position;
                _robotCollector.transform.rotation = Quaternion.identity;
            }
            else
            {
                Destroy(_robotCollector.gameObject);
            }
        }

        public void Initialize(UnityEvent On, UnityEvent Off)
        {
            _isCanRun = true;
            _isTurnedRight = true;

            On.AddListener(SwitchOn);
            Off.AddListener(SwitchOff);

            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _currentAdditionalJumps = _maxAdditionalJumps;

            SettingsData _settingsData = DataHolder.SettingsData;
            KeyCode[] controlKeys = _settingsData.GameControlPanelDt.GetControlKeys();
            _leftKey = controlKeys[0];
            _rightKey = controlKeys[1];
            _jumpKey = controlKeys[2];
            _runKey = controlKeys[3];
        }

        private void Update()
        {
            if (_isCanRun == false)
                return;

            bool isGrounded = IsGrounded();

            if (isGrounded)
            {
                _currentAdditionalJumps = _maxAdditionalJumps;
                _isMainJumpStay = true;
            }

            if (Input.GetKeyDown(_jumpKey))
            {
                if (isGrounded && _isMainJumpStay)
                {
                    Jump();
                    _isMainJumpStay = false;
                }
                else if (_currentAdditionalJumps > 0)
                {
                    Jump();
                    _currentAdditionalJumps--;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_isCanRun == false)
                return;

            if (Input.GetKey(_leftKey) && Input.GetKey(_rightKey) == false)
            {
                if (_horisontalInput > 0)
                    _horisontalInput = 0;
                if (_horisontalInput > -_maxSpeed)
                    _horisontalInput -= _currentSpeedChange;
            }
            else if (Input.GetKey(_rightKey) && Input.GetKey(_leftKey) == false)
            {
                if (_horisontalInput < 0)
                    _horisontalInput = 0;
                if (_horisontalInput < _maxSpeed)
                    _horisontalInput += _currentSpeedChange;
            }
            else
                _horisontalInput = 0f;

            if (_rigidBody.velocity.y <= 0)
                _animator.SetBool(PlayerAnimatorParameters.IsJump, false);

            if (_horisontalInput == 0)
            {
                _animator.SetBool(PlayerAnimatorParameters.IsRun, false);
                return;
            }
            else
                _animator.SetBool(PlayerAnimatorParameters.IsRun, true);

            Vector2 moveX = new Vector2(_horisontalInput, _rigidBody.velocity.y);

            if (moveX.x > 0 && _isTurnedRight == false)
            {
                Flip();
            }
            else if (moveX.x < 0 && _isTurnedRight)
            {
                Flip();
            }

            _rigidBody.velocity = moveX;
            if (_horisontalInput > 0)
                _horisontalInput -= _defaultSpeedChange;
            else if (_horisontalInput < 0)
                _horisontalInput += _defaultSpeedChange;
        }

        private void Jump()
        {
            _rigidBody.AddForce(new Vector2(0f, _jumpForce));
            _animator.SetBool(PlayerAnimatorParameters.IsJump, true);
        }

        private void Flip()
        {
            _isTurnedRight = !_isTurnedRight;
            Vector2 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private bool IsGrounded()
        {
            bool answer = false;
            if (Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _ground))
                answer = true;
            _animator.SetBool(PlayerAnimatorParameters.IsGrounded, answer);
            return answer;
        }

        private void SwitchOn()
        {
            _isCanRun = true;
        }

        private void SwitchOff()
        {
            _animator.SetBool(PlayerAnimatorParameters.IsRun, false);
            _isCanRun = false;
        }
    }
}
