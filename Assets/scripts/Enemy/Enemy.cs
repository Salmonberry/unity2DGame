using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform[] movePos;
    public Transform targetPoint;
    private int index;
    public Animator animator;
    public int animState;

    [Header("checkout enemys")] public List<Transform> attackList;
    private static readonly int HasWaite = Animator.StringToHash("hasWaite");

    public PatrolState patrolState = new PatrolState();
    public AttackState attackState = new AttackState();

    private EnemyBaseState currentState;
    private static readonly int State = Animator.StringToHash("state");

    public virtual void Init()
    {
        animator = GetComponent<Animator>();
    }

    void Awake()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        animator = GetComponent<Animator>();
        TransitionToState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        // PatrolAround();
        // PlayAnimation();

        currentState.OnUpdate(this);
        animator.SetInteger(State, animState);
    }

    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void PatrolAround()
    {
        targetPoint = movePos[index];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        FilpDirection();

        if (Mathf.Abs(transform.position.x - targetPoint.position.x) < 0.01f)
        {
            SwitchPoint();
        }
    }


    public void SwitchPoint()
    {
        // if (Mathf.Abs(movePos[0].position.x - transform.position.x) >
        //     Mathf.Abs(movePos[1].position.x - transform.position.x))
        // {
        //     index = 0;
        // }
        // else
        // {
        //     index = 1;
        // }

        GetFarPoint(transform,movePos);
    }

    /// <summary>
    /// 获取数组中与怪物相距最远的点
    /// </summary>
    /// <returns></returns>
    private PointWithDistance GetFarPoint(Transform self,IReadOnlyList<Transform> points)
    {
        var distanceList = new List<PointWithDistance>();
        for (var i = 0; i < points.Count; i++)
        {
            var point = points[index];
            var distance = Math.Abs(self.position.x - point.position.x);


            distanceList.Add(new PointWithDistance(point, distance));
        }

        distanceList.Sort((a, b) => a.Distance.CompareTo(b.Distance));

        return distanceList.Last();
    }

    public void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, this.targetPoint.transform.position,
            speed * Time.deltaTime);
        FilpDirection();
    }

    private void FilpDirection()
    {
        if (transform.position.x < targetPoint.position.x)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }


    private void PlayAnimation()
    {
        animator.SetBool(HasWaite, Vector2.Distance(transform.position, movePos[index].position) < 0.1f);
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (!attackList.Contains(collider2D.transform))
        {
            attackList.Add(collider2D.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        Debug.Log(collider2D.name);
        attackList.Remove(collider2D.transform);
    }

    public virtual void SkillAction() // 对炸弹使用技能 每个敌人不同的方式
    {
    }

    public virtual void AttackAction() //攻击玩家
    {
    }
}