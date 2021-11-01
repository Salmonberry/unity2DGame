﻿using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    public abstract void EnterState(Enemy enemy);
    public abstract void OnUpdate(Enemy enemy);
}