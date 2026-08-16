using UnityEngine;

public class GunItem : Item
{
    [SerializeField] private float _timeDestroyAfterShoot = 5f;
    [SerializeField] private float _speedShoot = 10f;

    private bool _isShoot = false;
    private Vector3 _shootDirection;

    public override void Update()
    {

        if (_isShoot)
        {
            _time += Time.deltaTime;

            gameObject.transform.Translate(_shootDirection * _speedShoot * Time.deltaTime, Space.World);

            if (_time >= _timeDestroyAfterShoot)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            base.Update();
        }
    }

    public override void UseAbility(Player player)
    {
        _time = 0f;

        _shootDirection = player.transform.forward;
        transform.rotation = Quaternion.LookRotation(_shootDirection) * Quaternion.Euler(90, 0, 0);

        if (_effectPrefab != null)
        {
            Instantiate(_effectPrefab, transform.position, transform.rotation);
        }

        transform.SetParent(null);

        _isShoot = true;
    }
}
