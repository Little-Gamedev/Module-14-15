using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private Player _player;

    public bool IsEmpty { get; private set; }

    private Item _currentItem = null;

    private void Awake()
    {
        IsEmpty = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Use();
        }
    }

    public void Put(Item item)
    {
        if (_currentItem != null) return;

        _currentItem = item;

        _currentItem.NotDestroy(true);
        _currentItem.PointToFree();

        _currentItem.transform.position = gameObject.transform.position;
        _currentItem.transform.SetParent(gameObject.transform, true);

        IsEmpty = false;

        Collider itemCollider = _currentItem.gameObject.GetComponent<Collider>();
        if (itemCollider == null) return;
        itemCollider.enabled = false;
    }

    public void Use()
    {
        if (_currentItem == null)
        {
            Debug.Log("Нечего использовать.Предмета нет");
            return;
        }

        _currentItem.UseAbility(_player);

        _currentItem = null;

        IsEmpty = true;
    }
}
