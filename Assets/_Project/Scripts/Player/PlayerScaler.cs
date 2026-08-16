using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Scale(other);
    }

    private void Scale(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item == null) return;

        float currentScale = gameObject.transform.localScale.x + item.ScaleValue;

        gameObject.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
