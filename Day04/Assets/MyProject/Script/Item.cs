using UnityEngine;

public class PointItem : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Destroy(gameObject);
    }
}
