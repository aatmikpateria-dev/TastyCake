using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    public float moveDistance = 3f;
    public float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, moveDistance);
        transform.position = startPos + Vector3.right * offset;
    }
}
