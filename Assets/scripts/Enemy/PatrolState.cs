using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.PatrolAround();
    }

    public override void OnUpdate(Enemy enemy)
    {
        enemy.PatrolAround();
        
    }
}
