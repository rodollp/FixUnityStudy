using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box")
        {
            Debug.Log("Player hit an Box!");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
