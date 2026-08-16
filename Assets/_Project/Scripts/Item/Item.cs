using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _destoryTime;
    private float _time;
    public abstract float ScaleValue { get; }

    private bool _isNotDestory = false;

    private ItemSpawnPoint _spawnPoint;

    public void SetSpawnPoint(ItemSpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _destoryTime && !_isNotDestory)
        {
            PointToFree();
            Destroy(gameObject);
        }
    }

    public void PointToFree()
    {
        if (_spawnPoint != null)
        {
            _spawnPoint.ToFree();
            _spawnPoint = null;
        }
    }

    public void NotDestroy(bool set)
    {
        _isNotDestory = set;
    }
}
