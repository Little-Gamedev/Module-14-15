using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent (typeof(Movement))]
public class Player : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _startTransform;

    private bool _isPaused = false;
    private bool _isHitting = false;

    public bool IsHitting => _isHitting;

    private void Awake()
    {
        _startTransform = transform.position;
    }

    private void Update()
    {
        if (_isPaused) return;
        Moving();
    }

    private void Moving()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Vector3 moveDirection = _movement.ProcessMove(input, _speed);

        _characterController.Move(moveDirection);

        transform.rotation = _movement.ProcessRotateTo(input, _rotationSpeed, transform, input);
    }

    public void NewGame()
    {
        if (_isPaused) _isPaused = false;
        if (_isHitting) _isHitting = false;

        _characterController.enabled = false;
        transform.position = _startTransform;
        _characterController.enabled = true;
    }

    public void Pause()
    {
        _isPaused = true;
    }
}
