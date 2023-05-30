using UnityEngine;

public class CameraRotate : MonoBehaviour, IService
{
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizontalSpeed;

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
        var cameraRotation = transform.eulerAngles;
        var value = _playerInput.Mouse.Look.ReadValue<Vector2>();


        cameraRotation.x -= value.y * _verticalSpeed * Time.deltaTime;
        cameraRotation.y += value.x * _horizontalSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(cameraRotation);
    }
}
