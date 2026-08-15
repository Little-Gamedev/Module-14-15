using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float DeadZone = 0.1f;

    public Vector3 ProcessMove(Vector3 direction, float speed)
    {
        if (direction.magnitude <= DeadZone)
            return Vector3.zero;

        return direction.normalized * speed * Time.deltaTime;
    }

    public Quaternion ProcessRotateTo(Vector3 direction, float rotationSpeed, Transform transformObject)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = rotationSpeed * Time.deltaTime;

        Quaternion transformRotation = transformObject.rotation;

        return Quaternion.RotateTowards(transformRotation, lookRotation, step);
    }

    public Quaternion ProcessRotateTo(Vector3 direction, float rotationSpeed, Transform transformObject, Vector3 input)
    {
        if (input.magnitude <= DeadZone)
        {
            return transformObject.rotation;
        }
        if (direction == Vector3.zero)
        {
            return transformObject.rotation;
        }

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = rotationSpeed * Time.deltaTime;

        Quaternion transformRotation = transformObject.rotation;

        return Quaternion.RotateTowards(transformRotation, lookRotation, step);
    }
}
