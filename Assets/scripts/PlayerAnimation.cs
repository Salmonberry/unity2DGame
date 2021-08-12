using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private PlayerControler _playerControler;
    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int Jump = Animator.StringToHash("jump");
    private static readonly int FallSpeed = Animator.StringToHash("fallSpeed");
    private static readonly int IsGround = Animator.StringToHash("isGround");
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerControler = GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayRunAnimation();
        PlayJumpAnimation();
        PlayFallAnimation();
        PlayGroundAnimation();
    }

    private void PlayRunAnimation() => _animator.SetFloat(Speed, Mathf.Abs(_rigidbody.velocity.x));
    private void PlayJumpAnimation() => _animator.SetBool(Jump, _playerControler.isJump);
    private void PlayFallAnimation() => _animator.SetFloat(FallSpeed, _rigidbody.velocity.y);
    private void PlayGroundAnimation() => _animator.SetBool(IsGround, _playerControler.isGround);

}