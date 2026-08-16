using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _destoryTime;

    [SerializeField] protected ParticleSystem _effectPrefab;

    private ItemSpawnPoint _spawnPoint;

    protected Transform _effectTransform;

    protected float _time;

    private bool _isNotDestory = false;

    private void Awake()
    {
        GetEffectTransform(gameObject.transform);
    }

    protected Transform GetEffectTransform(Transform transform)
    {
        return _effectTransform = transform;
    }

    public void SetSpawnPoint(ItemSpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public virtual void Update()
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

    public virtual void UseAbility(Player player)
    {
        if (_effectPrefab != null)
        {
            Instantiate(_effectPrefab, GetEffectTransform(_effectTransform).position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
