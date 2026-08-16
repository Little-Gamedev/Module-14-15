using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _itemContainerTransform;

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
        item.NotDestroy(true);
        item.transform.position = _itemContainerTransform.position;
        item.transform.SetParent(_itemContainerTransform, true);
        item.PointToFree();

        Collider itemCollider = item.gameObject.GetComponent<Collider>();
        if (itemCollider == null) return;
        itemCollider.enabled = false;
    }
}
