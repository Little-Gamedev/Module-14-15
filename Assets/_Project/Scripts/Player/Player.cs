using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private int _health = 1;

    [SerializeField] private Transform _legsEffectTransform;
    public Transform LegsEffectTransform => _legsEffectTransform;

    private Vector3 _startTransform;

    public Vector3 MoveDirection { get; private set; }

    private bool _isPaused = false;
    private bool _isHitting = false;

    public bool IsHitting => _isHitting;

    #region Временная реализация UI
    [SerializeField] private TextMeshProUGUI _healthInfoTmp;
    [SerializeField] private TextMeshProUGUI _speedInfoTmp;
    #endregion

    private void Awake()
    {
        _startTransform = transform.position;
        UIUpdate();
    }

    private void Update()
    {
        if (_isPaused) return;
        Moving();
    }

    private void Moving()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        MoveDirection = _movement.ProcessMove(input, _speed);

        _characterController.Move(MoveDirection);

        transform.rotation = _movement.ProcessRotateTo(input, _rotationSpeed, transform, input);
    }

    private void UIUpdate()
    {
        _healthInfoTmp.text = _health.ToString();
        _speedInfoTmp.text = _speed.ToString();
    }

    public void NewGame()
    {
        if (_isPaused) _isPaused = false;
        if (_isHitting) _isHitting = false;

        _characterController.enabled = false;
        transform.position = _startTransform;
        _characterController.enabled = true;
    }

    public void AddHealth(int value)
    {
        _health += value;
        UIUpdate();
    }

    public void AddSpeed(float value)
    {
        _speed += value;
        UIUpdate();
    }

    public void Pause()
    {
        _isPaused = true;
    }
}
