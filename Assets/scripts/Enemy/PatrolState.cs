using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
     
    }

    public override void OnUpdate(Enemy enemy)
    {
        enemy.PatrolAround();
    }
}
