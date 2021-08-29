using System;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("Player Attribute")] public float speed = 5;
    private Rigidbody2D _rigidbody2D;
    public float skillCooldown;
    private float _skillCooldownTime = 0;
    [SerializeField] public bool isJump;
    private PlayerTowards _playerTowards;

    [Header("Ground Check")] public LayerMask checkedType;
    public Transform detector;
    public float colliderRadius;
    public bool isGround;

    [Header("Attack")] public GameObject bomb;

    private GameObject _playerControllerParent;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerControllerParent = GameObject.Find("PlayerController");
    }

    private void Update()
    {
        ONAttack();
        Debug.Log(Time.time);
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

            switch (horizontal)
            {
                case 1:
                    _playerTowards = PlayerTowards.TowardsToRight;
                    break;
                case -1:
                    _playerTowards = PlayerTowards.TowardsToLeft;
                    break;
            }
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

    private void ONAttack()
    {
        //技能开启时间
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(Time.time);
            if (Time.time > _skillCooldownTime)
            {
                GenerateBomb();
                _skillCooldownTime = Time.time + skillCooldown;
            }
        }
    }

    private void GenerateBomb()
    {
        var toward = _playerTowards == PlayerTowards.TowardsToRight ? 1 : -1;
        var position = gameObject.transform.position + new Vector3(2 * toward, 2, 0);

        var bombPrefab = Instantiate(bomb, position, Quaternion.identity, _playerControllerParent.transform)
            .GetComponent<Rigidbody2D>();
        bombPrefab.velocity = new Vector2(toward * 10, 0);
        bombPrefab.gravityScale = 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(detector.position, colliderRadius);
    }
}