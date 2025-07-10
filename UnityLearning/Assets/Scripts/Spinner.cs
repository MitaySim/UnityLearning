using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed = 100f;
    private int direction = 1;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * direction * Time.deltaTime);
    }

    public void ReverseDirection()
    {
        direction *= -1;
    }
}

