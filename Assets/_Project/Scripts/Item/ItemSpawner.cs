using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private List<ItemSpawnPoint> _itemSpawnPoints;

    [SerializeField] private float _cooldown;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _cooldown)
        {
            Spawn(_items, _itemSpawnPoints);
        }
    }

    private void Spawn(List<Item> items, List<ItemSpawnPoint> points)
    {
        List<ItemSpawnPoint> emptyPoints = GetEmptyPoints();

        if (emptyPoints.Count == 0)
        {
            _time = 0;
            return;
        }

        ItemSpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

        Item item = Instantiate(_items[Random.Range(0, _items.Count)], spawnPoint.Position, Quaternion.identity);

        spawnPoint.Occupy(item);
        item.SetSpawnPoint(spawnPoint);

        _time = 0;
    }

    private List<ItemSpawnPoint> GetEmptyPoints()
    {
        List<ItemSpawnPoint> emptyPoints = new List<ItemSpawnPoint>();

        foreach (ItemSpawnPoint point in _itemSpawnPoints)
            if (point.IsEmpty) emptyPoints.Add(point);

        return emptyPoints;
    }
}
