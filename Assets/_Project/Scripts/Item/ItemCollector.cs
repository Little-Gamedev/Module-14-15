using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private ItemContainer _itemContainer;

    private void OnTriggerEnter(Collider other)
    {
        Add(other);
    }

    private void Add(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item == null) return;

        Collect(item);
    }

    private void Collect(Item item)
    {
        if (!_itemContainer.IsEmpty) return;

        _itemContainer.Put(item);
    }
}
