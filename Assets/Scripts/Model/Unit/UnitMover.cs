using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitMover : MonoBehaviour, IService
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _backSpeed;

    private Fsm _fsm;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _fsm = new Fsm();
        _rigidBody = GetComponent<Rigidbody>();

        _fsm.AddState(new StateIdle(_fsm));
        _fsm.AddState(new StateForward(_fsm));
        _fsm.AddState(new StateLeft(_fsm));
        _fsm.AddState(new StateRight(_fsm));
        _fsm.AddState(new StateBack(_fsm));

        _fsm.SetState<StateIdle>();
    }

    private void OnDisable()
    {
        Stay();
    }

    private void Update()
    {
        _fsm.Update();
    }

    public void Stay()
    {
        _rigidBody.velocity = Vector3.zero;
    }

    public void MoveForward()
    {
        _rigidBody.velocity += transform.forward * _forwardSpeed * Time.deltaTime;
        Clamp(transform.forward, _forwardSpeed);
    }

    public void MoveBack()
    {
        _rigidBody.velocity -= transform.forward * _backSpeed * Time.deltaTime;
        Clamp(-transform.forward, _backSpeed);
    }

    public void MoveLeft()
    {
        _rigidBody.velocity -= transform.right * _sideSpeed * Time.deltaTime;
        Clamp(-transform.right, _sideSpeed);
    }

    public void MoveRight()
    {
        _rigidBody.velocity += transform.right * _sideSpeed * Time.deltaTime;
        Clamp(transform.right, _sideSpeed);
    }

    private void Clamp(Vector3 direction, float maxValue)
    {
        if (_rigidBody.velocity.magnitude >= maxValue)
        {
            _rigidBody.velocity = direction * maxValue;
        }
    }
}
