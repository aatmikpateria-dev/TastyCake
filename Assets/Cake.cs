using UnityEngine;

public class Cake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCake();
            Destroy(gameObject);
        }
    }
}
