using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    public int waypointFinder;

    public override void Enter()
    {
    }
    public override void Perform()
    {
        ChaseCycle();
    }
    public override void Exit()
    {
    }

    public void ChaseCycle()
    {
        enemy.Agent.SetDestination(enemy.playerLoc.position);
    }
}
