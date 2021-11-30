using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.animState = 0;
        enemy.PatrolAround();
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (!enemy.animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            enemy.animState = 1;
            enemy.PatrolAround();
        }

        if (enemy.attackList.Count > 0)
        {
            Debug.Log("attackList don't null");
            enemy.TransitionToState(enemy.attackState);
        }
    }
}