using UnityEngine;

public class AttackState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.animState = 2;
        enemy.targetPoint = enemy.attackList[0];
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (enemy.attackList.Count == 0)
        {
            enemy.TransitionToState(enemy.patrolState);
        }

        if (enemy.attackList.Count > 0)
        {
            float currentPositionToTargetDistance =
                Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.transform.position.x);

            foreach (var item in enemy.attackList)
            {
                float currentPositionToAttackListDistance =
                    Mathf.Abs(enemy.transform.position.x - item.transform.position.x);

                if (currentPositionToTargetDistance < currentPositionToAttackListDistance)
                {
                    enemy.targetPoint = item;
                }
            }

            enemy.MoveToTarget();
        }
    }
}