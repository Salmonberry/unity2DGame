using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D _rigidbody2D;
    public bool isJump;

    [Header("Ground Check")] public LayerMask checkedType;
    public Transform detector;
    public float colliderRadius;
    public bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        _rigidbody2D.velocity = new Vector2(horizontal * speed, _rigidbody2D.velocity.y);

        if (horizontal != 0)
        {
            transform.localScale = new Vector3(horizontal, 1, 1);
        }
    }


    private void Jump()
    {
        isJump = Input.GetButtonDown("Jump");
        isGround = Physics2D.OverlapCircle(detector.position, colliderRadius, checkedType);
        _rigidbody2D.gravityScale = 1;

        if (isJump && isGround)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, speed);
            _rigidbody2D.gravityScale = 4;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(detector.position, colliderRadius);
    }
}