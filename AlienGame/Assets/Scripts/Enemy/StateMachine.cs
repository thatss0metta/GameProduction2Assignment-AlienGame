using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    public ChaseState chaseState;
    public StunnedState stunnedState;
    public FieldOfView fov;

    public void Initialize()
    {
        patrolState = new PatrolState();
        chaseState = new ChaseState();
        stunnedState = new StunnedState();
        ChangeState(patrolState);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(activeState != null)
        {
            activeState.Perform();
        }
        if(fov.canSeePlayer)
        {
            ChangeState(chaseState);
        }
        else if(!fov.canSeePlayer)
        {
            ChangeState(patrolState);
        }
    }

    public void ChangeState(BaseState newState)
    {
        // Check activeState != null
        if(activeState != null)
        {
            // Run cleanup
            activeState.Exit();
        }
        // Change to new state
        activeState = newState;

        // Fail-safe null check to make sure new state wasn't null
        if(activeState != null)
        {
            // Setup new state.
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();

        }
    }
}
