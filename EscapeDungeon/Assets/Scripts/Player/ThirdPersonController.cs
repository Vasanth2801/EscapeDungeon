using Unity.Burst;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;                 // Reference for the Character Controller
    public Transform cam;                                  // Reference for the camera
    public Animator animator;                             // Reference for the player animator
    public Transform attackPoint;                         // Reference for the attackPoint
    public float attackRange = 0.7f;                      // Attack range to attack the enemy
    public float speed = 5f;                             // Speed of the player moving
    public LayerMask enemyLayer;                         // Layermask for the enemy attack
    public int damage = 10;                             //damage doing to the enemy 
    public float smoothSpeed = 0.025f;                    // Smooth turning value for the Camera turning
    float currentVelocity;                                // Reference for the camera reference velocity for smooth
    
    //Awake Called before the first function of the update
    private void Awake()
    {
        animator = GetComponent<Animator>();          // Calling the animator component for the player
    }

    
    // Called for once per every update
    private void Update()
    {
        Attack();           // Attacking Logic
        Move();             //Moving Logic
    }


    // Method for attacking the player
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))        // If left click of the mouse is pressed
        {
            animator.SetTrigger("Attack");         //Animation for the Attack

            Collider[] hitInfo = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);       //Attacking Logic

            foreach(Collider enemy in hitInfo)
            {
                enemy.GetComponent<EnemyHealth>().currentHealth -= damage;     // Here we can do reduce the enemy health when player is damaging 
            }
        }
    }

    //  Method for the Moving the Player 
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");                      // Horizontal input to move horizontal
        float vertical = Input.GetAxisRaw("Vertical");                         // Vertical input to move vertically 
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;  //  Direction for the Player to move in x and z axis 

        if (direction.magnitude > 0.01f)                                    // if the force of the direction we are going greater than 0.01 
        {
            Run();                                                         //Calling the Run Method
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;          // Angle for the camera to move along with camera 
            float rotateAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref currentVelocity, smoothSpeed);   // Smooth turning camera according to player movement 
            transform.rotation = Quaternion.Euler(0f, rotateAngle, 0f);                                    // Rotation for the player

            Vector3 moveDirection = Quaternion.Euler(0, rotateAngle, 0) * Vector3.forward;        // Combining the angle and direction 
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);                 // Moving the Player with desired speed

        }
        else
        {
            Idle();                                                    // idle Method
        }
    }

    void Run()
    {
        animator.SetFloat("Speed", 1);              // Animation to play when the float is 1
    }

    void Idle()
    {
        animator.SetFloat("Speed", 0);                //Animation to play when the float is 0 
    }

    // Checking the Attack Range in the Editor 
    private void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);        // Show the AttackRange in editor ins sphere shape 
        }
        else
        {
            return;
        }
        
    }
}
