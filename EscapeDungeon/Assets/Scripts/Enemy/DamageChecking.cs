using UnityEngine;

public class DamageChecking : MonoBehaviour
{
    public float damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.currentHealth -= damage;

            if(PlayerHealth.Instance.currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
