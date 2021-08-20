using UnityEngine;

public class EffectAnimation : MonoBehaviour
{
    [Header("resource")] public GameObject jumpAnimationEffect;
    public GameObject groundAnimationEffect;
    private PlayerControler _playerControler;
    private static readonly int IsJump = Animator.StringToHash("isJump");
    private Vector3 _originalPosition;
    private Vector3 _jumpEffectAnimationPosition;
    private Vector3 _groundEffectAnimationPosition;
    private Vector3 _playerPosition;
    private Rigidbody2D _rigidbody2D;
    private Animator _playerAnimator;
    private static readonly int FallSpeed = Animator.StringToHash("fallSpeed");


    // Start is called before the first frame update
    private void Start()
    {
        _originalPosition = gameObject.transform.position;
        _playerControler = GetComponent<PlayerControler>();
        _playerAnimator = _playerControler.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayJumpEffectAnimation();

        Debug.Log("速度：" + _playerControler.PlayerVelocity);
        Debug.Log("y轴速度：" + _playerControler.PlayerVelocity.y);
        Debug.Log("x轴速度：" + _playerControler.PlayerVelocity.x);
        Debug.Log(_playerAnimator.GetBool(FallSpeed));
        
        
    }


    /*跳跃动画特效*/
    private void PlayJumpEffectAnimation()
    {
        _playerPosition = gameObject.transform.position;

        if (!_playerControler.isJump) return;
        /*跳跃动画特效*/
        _jumpEffectAnimationPosition = jumpAnimationEffect.transform.position;
        _jumpEffectAnimationPosition = new Vector3(_playerPosition.x,
            _jumpEffectAnimationPosition.y, _jumpEffectAnimationPosition.z);
        jumpAnimationEffect.transform.position = _jumpEffectAnimationPosition;
        jumpAnimationEffect.SetActive(true);
    }

    /*下落动画特效*/
    public void PlayGroundEffectAnimation()
    {
        groundAnimationEffect.SetActive(true);
        _groundEffectAnimationPosition = groundAnimationEffect.transform.position;
        _groundEffectAnimationPosition = new Vector3(_playerPosition.x,
            _groundEffectAnimationPosition.y, _groundEffectAnimationPosition.z);
        groundAnimationEffect.transform.position = _groundEffectAnimationPosition;
        
    }
}