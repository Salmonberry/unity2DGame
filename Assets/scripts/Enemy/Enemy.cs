using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    private int index;
    private Animator _animator;
    [Header("checkout enemys")] public List<Transform> detectEnemys;
    private static readonly int HasWaite = Animator.StringToHash("hasWaite");

    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // PatrolAround();
        PlayAnimation();
    }

    public void PatrolAround()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos[index].position) < 0.1f)
        {
            if (waitTime < 0.0f)
            {
                if (index == 0)
                {
                    index = 1;
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else
                {
                    index = 0;
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }

                waitTime = 0.5f;
            }
            else
            {
                // _animator.SetBool();
                waitTime -= Time.deltaTime;
            }
        }
    }



    private void PlayAnimation()
    {
        _animator.SetBool(HasWaite, Vector2.Distance(transform.position, movePos[index].position) < 0.1f);
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (!detectEnemys.Contains(collider2D.transform))
        {
            detectEnemys.Add(collider2D.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        Debug.Log(collider2D.name);
        detectEnemys.Remove(collider2D.transform);
    }

    public virtual void SkillAction() // 对炸弹使用技能 每个敌人不同的方式
    {
    }

    public virtual void AttackAction() //攻击玩家
    {
    }
}