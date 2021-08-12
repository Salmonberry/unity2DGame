using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimation : MonoBehaviour
{
    [Header("resource")] private Animator _effectAnimator;
    public GameObject jumpAnimationEffect;
    private PlayerControler _playerControler;   
    private static readonly int IsJump = Animator.StringToHash("isJump");

    // Start is called before the first frame update
    private void Start()
    {
        _effectAnimator = jumpAnimationEffect.GetComponent<Animator>();
        _playerControler = GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate: "+_playerControler.isJump);
        if (_playerControler.isJump)
        {
            Debug.Log("EffectAnimation: "+_effectAnimator);
            Debug.Log("dadasdsadasdsadas");
            jumpAnimationEffect.SetActive(true);
        }
        else
        {
            jumpAnimationEffect.SetActive(false);
        }
    }
}