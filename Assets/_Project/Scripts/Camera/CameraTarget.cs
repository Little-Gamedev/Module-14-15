using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void Awake()
    {
        _target = transform;
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = _target.transform.position + _offset;
    }
}
