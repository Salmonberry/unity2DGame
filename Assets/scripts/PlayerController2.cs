using UnityEngine;


public class PlayerController2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [Header("move speed")] public float speed;
    [Header("jump speed")] public float jumpSpeed;
    [Header("detected")] public LayerMask layerMask;
    private BoxCollider2D _groundDetected;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundDetected = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    private void Run()                                                                                                      
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        _rigidbody2D.velocity = new Vector2(horizontal * speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        bool isJump = Input.GetButtonDown("Jump");
        Debug.Log("isJump" + isJump);

        bool isGround = _groundDetected.IsTouchingLayers(layerMask);
        if (isJump && isGround)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
        }
    }
}