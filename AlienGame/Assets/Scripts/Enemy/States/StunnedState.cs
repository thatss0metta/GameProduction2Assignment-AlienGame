using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunnedState : BaseState
{
    public int waypointFinder;

    public override void Enter()
    {
    }
    public override void Perform()
    {
        StunCycle();
    }
    public override void Exit()
    {
    }

    public void StunCycle()
    {
        enemy.fov.canSeePlayer = false;
    }
}
