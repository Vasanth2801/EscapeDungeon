using System.Collections;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public Animator animator;
    public float duration = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PickUp());
        }
    }


    IEnumerator PickUp()
    {
        animator.SetBool("isOpen", true);
        ScoreManager.instance.AddScore(50);
        Debug.Log("Chest Picked up");
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
