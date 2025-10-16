using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.7f;
    public float speed = 5f;
    public LayerMask enemyLayer;

    public float smoothSpeed = 0.025f;
    float currentVelocity;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
        Move();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");

            Collider[] hitInfo = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

            foreach(Collider enemy in hitInfo)
            {
                Debug.Log("Damaged Player");
            }
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude > 0.01f)
        {
            Run();
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float rotateAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref currentVelocity, smoothSpeed);
            transform.rotation = Quaternion.Euler(0f, rotateAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0, rotateAngle, 0) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        }
        else
        {
            Idle();
        }
    }

    void Run()
    {
        animator.SetFloat("Speed", 1);
    }

    void Idle()
    {
        animator.SetFloat("Speed", 0);
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
        else
        {
            return;
        }
        
    }
}
