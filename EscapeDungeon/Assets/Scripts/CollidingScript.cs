using UnityEngine;

public class CollidingScript : MonoBehaviour
{
    float damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().currentHealth -= damage;
        }
    }
}
