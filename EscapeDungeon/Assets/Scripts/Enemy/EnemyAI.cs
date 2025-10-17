using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;                    // Range for the Enemy to follow the player

    NavMeshAgent agent;                            //Reference for the NavmeshAgent to make the enemy move
    Transform target;                              // target for the enemy to follow 


    // Called First frame of the game 
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;          // Finding the player target 
        agent = GetComponent<NavMeshAgent>();                                   // Getting our navmesh agent component
    }

    // It is called once per every frame 
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);         // Calculate the distance between the player and enemy

        if(distance <= lookRadius)          // if the distance is less than look radius 
        {
            agent.SetDestination(target.position);        // set the destination as player to follow 
        }
    }

    // The checking area for chasing 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
