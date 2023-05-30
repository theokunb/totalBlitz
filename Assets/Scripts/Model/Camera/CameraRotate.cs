using UnityEngine;

public class CameraRotate : MonoBehaviour, IService
{
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _angle;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Mouse.Look.performed += OnLook;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var cameraRotation = transform.rotation.eulerAngles;
        var value = _playerInput.Mouse.Look.ReadValue<Vector2>();

        cameraRotation.x -= value.y * _verticalSpeed * Time.deltaTime;
        cameraRotation.y += value.x * _horizontalSpeed * Time.deltaTime;

        cameraRotation = Clamp(cameraRotation);

        transform.rotation = Quaternion.Euler(cameraRotation);
    }

    private Vector3 Clamp(Vector3 euler)
    {
        if((euler.x > 0 && euler.x < _angle) || (euler.x < 360 && euler.x > (360 - _angle)))
        {
            return euler;
        }
        else if(euler.x > _angle && euler.x < 180)
        {
            euler.x = _angle;
        }
        else if(euler.x < (360 - _angle) && euler.x >= 180)
        {
            euler.x = 360 - _angle;
        }

        return euler;
    }
}
