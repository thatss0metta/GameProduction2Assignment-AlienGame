using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    // Track current waypoint targeted.
    public int waypointIndex;
    public float waitTimer;

    public override void Enter()
    {
    }
    public override void Perform()
    {
        PatrolCycle();
    }
    public override void Exit()
    {
    }

    public void PatrolCycle()
    {
        Debug.Log("Patrolling");
        // Implement our patrol logic
        if(enemy.Agent.remainingDistance < 0.5f)
        {
            waitTimer += Time.deltaTime;
            Debug.Log("Timer: " + waitTimer);
            if(waitTimer > 3)
            {
                if(waypointIndex < enemy.path.waypoints.Count - 1)
                {
                    waypointIndex++;
                    Debug.Log("Index is: " + waypointIndex);
                }
                else
                {
                    Debug.Log("Index changed to " + waypointIndex);
                    waypointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                waitTimer = 0;
            }
        }
    }
}
