using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(50);
            Debug.Log("Chest Picked up");
            Destroy(gameObject);
        }
    }
}
