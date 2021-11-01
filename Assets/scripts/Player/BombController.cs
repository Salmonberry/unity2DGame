using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombController : MonoBehaviour
{
    [Header("delay time to bomb")] public float delayTime;
    private float _bombTime;

    private Animator _animator;

    [Header("check out collide witth Bomb")]
    public LayerMask checkedType;

    public float colliderRadius;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        _bombTime = Time.time + delayTime;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Explosion();
    }

    private void Explosion()
    {
        if (Time.time > _bombTime)
        {
            _animator.Play("ExplotionAnimation");
            var chekoutList = Physics2D.OverlapCircleAll(gameObject.transform.position, colliderRadius, checkedType);
            foreach (var item in chekoutList)
            {
                ///获取碰撞物的方向
                Vector3 vectorDirection = (gameObject.transform.position - item.GetComponent<Transform>().position)
                    .normalized;

                item.GetComponent<Rigidbody2D>().AddForce(vectorDirection * force);
            }
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(gameObject.transform.position, colliderRadius);
    }
}