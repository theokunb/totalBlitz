using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class UnitMover : MonoBehaviour
{
    private const float DampTime = 0.05f;
    private const float Distance = 0.5f;

    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _backSpeed;
    [SerializeField] private Input _input;

    private Fsm _fsm;
    private Rigidbody _rigidBody;
    private Animator _animator;

    private void Start()
    {
        _fsm = new Fsm();
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        State idleState = new StateIdle(_fsm, this);
        State forwardState = new StateForward(_fsm, this);
        State leftState = new StateLeft(_fsm, this);
        State backState = new StateBack(_fsm, this);
        State rightState = new StateRight(_fsm, this);
        State lookingDirectionState = new StateLookingDirection(_fsm, this);

        Condition conditionOnIdle = new ConditionOnIdle(idleState, _input);

        Condition conditionOnForward = new ConditionOnForward(forwardState, _input);
        Condition conditionOnLeft = new ConditionOnLeft(leftState, _input);
        Condition conditionOnBack = new ConditionOnBack(backState, _input);
        Condition conditionRight = new ConditionOnRight(rightState, _input);

        Condition checkForward = new CheckForward(lookingDirectionState, this, Distance);
        Condition checkLeft = new CheckLeft(lookingDirectionState, this, Distance);
        Condition checkBack = new CheckBack(lookingDirectionState, this, Distance);
        Condition checkRight = new CheckRight(lookingDirectionState, this, Distance);

        Condition allowForward = new AllowForward(forwardState, this, Distance);
        Condition allowLeft = new AllowLeft(leftState, this, Distance);
        Condition allowRight = new AllowRight(backState, this, Distance);
        Condition allowBack = new AllowBack(rightState, this, Distance);

        Condition isForwardDirection = new IsForwardDirection(forwardState, _input, this, Distance);
        Condition isLeftDirection = new IsLeftDirection(leftState, _input, this, Distance);
        Condition isBackDirection = new IsBackDirection(backState, _input, this, Distance);
        Condition isRightDirection = new IsRightDirection(rightState, _input, this, Distance);

        AddConditions(idleState, conditionOnForward, conditionOnLeft, conditionOnBack, conditionRight);

        AddConditions(forwardState, conditionOnIdle, checkForward, isLeftDirection, isBackDirection, isRightDirection);
        AddConditions(leftState, conditionOnIdle, checkLeft, isForwardDirection, isBackDirection, isRightDirection);
        AddConditions(backState, conditionOnIdle, checkBack, isForwardDirection, isLeftDirection, isRightDirection);
        AddConditions(rightState, conditionOnIdle, checkRight, isForwardDirection, isLeftDirection, isBackDirection);

        AddConditions(lookingDirectionState, conditionOnIdle, allowForward, allowLeft, allowRight, allowBack);

        _fsm.AddState(idleState);
        _fsm.AddState(forwardState);
        _fsm.AddState(leftState);
        _fsm.AddState(rightState);
        _fsm.AddState(backState);
        _fsm.AddState(lookingDirectionState);

        _fsm.SetState(idleState);
    }

    private void OnDisable()
    {
        Stay();
    }

    private void FixedUpdate()
    {
        _fsm.Update();
    }

    public bool HaveObstacle(Vector3 direction)
    {
        return Physics.OverlapSphere(transform.position + direction + transform.up / 2, 0.35f).Where(element => element.TryGetComponent(out Wall _) == true).Count() > 0;
    }

    private void AddConditions(State state, params Condition[] conditions)
    {
        foreach (Condition condition in conditions)
        {
            state.AddCondition(condition);
        }
    }

    public void Stay()
    {
        _rigidBody.velocity = Vector3.zero;
        _animator.SetFloat(AnimationParameters.Params.MoveValue, AnimationParameters.Values.Idle, DampTime, Time.deltaTime);
    }

    public void MoveForward()
    {
        _rigidBody.velocity = transform.forward * _forwardSpeed * Time.deltaTime;
        Clamp(transform.forward, _forwardSpeed);
        _animator.SetFloat(AnimationParameters.Params.MoveValue, AnimationParameters.Values.Forward, DampTime, Time.deltaTime);
    }

    public void MoveBack()
    {
        _rigidBody.velocity = -transform.forward * _backSpeed * Time.deltaTime;
        Clamp(-transform.forward, _backSpeed);
        _animator.SetFloat(AnimationParameters.Params.MoveValue, AnimationParameters.Values.Back, DampTime, Time.deltaTime);
    }

    public void MoveLeft()
    {
        _rigidBody.velocity = -transform.right * _sideSpeed * Time.deltaTime;
        Clamp(-transform.right, _sideSpeed);
        _animator.SetFloat(AnimationParameters.Params.MoveValue, AnimationParameters.Values.Left, DampTime, Time.deltaTime);
    }

    public void MoveRight()
    {
        _rigidBody.velocity = transform.right * _sideSpeed * Time.deltaTime;
        Clamp(transform.right, _sideSpeed);
        _animator.SetFloat(AnimationParameters.Params.MoveValue, AnimationParameters.Values.Right, DampTime, Time.deltaTime);
    }

    private void Clamp(Vector3 direction, float maxValue)
    {
        if (_rigidBody.velocity.magnitude >= maxValue)
        {
            _rigidBody.velocity = direction * maxValue;
        }
    }
}

public static class AnimationParameters
{
    public static class Params
    {
        public static string MoveValue = "MoveValue";
    }

    public static class Values
    {
        public static float Idle = 0f;
        public static float Forward = 0.25f;
        public static float Left = 0.5f;
        public static float Back = 0.75f;
        public static float Right = 1f;
    }
}