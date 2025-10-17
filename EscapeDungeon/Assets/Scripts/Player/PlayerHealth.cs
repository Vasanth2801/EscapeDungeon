using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;              // Singleton Implementation
    public float currentHealth;                       // Current Health of the player
    public float maxHealth = 100;                     // Maximum health of the player
    public Image healthBar;                           // Health bar refrence we have created


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;                   // setting our currentHealth as our maximum health 
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth/maxHealth,0,1);           // Setting the image fill amount to 0 to 1
    }
}
