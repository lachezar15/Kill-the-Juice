using UnityEngine;

public class GlassJuiceMovement : MonoBehaviour
{
    private Transform player;
    
    public Rigidbody rb;

    private string state = "Idle"; //Idle, Chasing, Attacking

    public Vector3 moveDirection;
    public float rotationSpeed = 5;

    public Animator anim;

    public float attackRange;
    public bool inAttackRange;
    bool alreadyAttacked = false;

    public float jumpForce = 10;
    public float forwardForce = 5;

    public LayerMask whatIsPlayer;

    public bool releasedFromFridge = false;
    private float timeReleasedFromFridge;
    private float timeTakingToEscape;
    bool escaped = false;
    public float escapeForce = 5;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeTakingToEscape = Random.Range(0.5f, 3);
    }

    private void Update()
    {
        if (releasedFromFridge == false)
            return;

        timeReleasedFromFridge += Time.deltaTime;

        if (timeReleasedFromFridge >= timeTakingToEscape && escaped == false)
        {
            rb.AddForce(transform.forward * escapeForce, ForceMode.Impulse);
            escaped = true;
        }
    }

    private void FixedUpdate()
    {
        if (!releasedFromFridge)
            return;

        inAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (inAttackRange == true)
        {
            state = "Attack";
        }
        else
        {
            state = "Chasing";
        }

        if (state == "Chasing")
        {
            ChasePlayer();
        }
        else if (state == "Idle")
        {
            LookTowardsPlayer();
            if (anim.GetBool("IsWalking") == true)
                anim.SetBool("IsWalking", false);
        }
        else if (state == "Attack" && alreadyAttacked == false)
        {
            rb.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Attack");
            alreadyAttacked = true;
        }

        if (transform.position.y > 1.5f)
        {
            rb.AddForce(transform.forward * 1.2f, ForceMode.Impulse);
        }
    }

    private void LookTowardsPlayer()
    {
        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0f; // ignore vertical difference
        if (lookDirection.sqrMagnitude < 0.001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        // Smooth rotation over time
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private void ChasePlayer()
    {
        LookTowardsPlayer();
        transform.Translate(moveDirection * Time.fixedDeltaTime, Space.Self);
        if (anim.GetBool("IsWalking") == false)
            anim.SetBool("IsWalking", true);
    }
}
