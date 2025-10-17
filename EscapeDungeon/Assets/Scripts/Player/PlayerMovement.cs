using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed = 5f;
    public LayerMask enemyLayer;
    public float attackRange = 2;
    public Transform attackPoint;
    int damage = 10;

    private void Update()
    {
        Attack();
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move* speed * Time.deltaTime);
    }


    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");

            Collider[] hitInfo = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

            foreach(Collider enemy in hitInfo)
            {
                enemy.GetComponent<EnemyHealth>().currentHealth -= damage;
            }
        }
    }
}
