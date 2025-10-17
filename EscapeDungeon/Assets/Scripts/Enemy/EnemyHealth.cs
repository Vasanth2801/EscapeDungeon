using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 30;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore(10);
            Debug.Log("Enemy Destroyed");
        }
    }
}
