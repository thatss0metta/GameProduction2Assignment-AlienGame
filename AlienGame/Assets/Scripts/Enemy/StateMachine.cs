using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    public ChaseState chaseState;
    public StunnedState stunnedState;
    public FieldOfView fov;
    public float rageTimer;
    public AudioSource audioSource;
    public bool isRaging = false;
    public GameObject rageText;

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
        rageTimer = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
        if (fov.canSeePlayer)
        {
            ChangeState(chaseState);
        }
        else if (!fov.canSeePlayer)
        {
            ChangeState(patrolState);
        }
        rageTimer += Time.deltaTime;
        // Debug.Log("Rage Time: " + rageTimer);
        if (rageTimer >= 30)
        {
            if (!isRaging)
            {
                audioSource.Play();
                Debug.Log("If statement Triggered");
                patrolState.adjustedTimer = 1;
                GetComponent<NavMeshAgent>().speed = 8;
                isRaging = true;
                rageText.SetActive(true);
            }
        }
    }

    public void ChangeState(BaseState newState)
    {
        // Check activeState != null
        if (activeState != null)
        {
            // Run cleanup
            activeState.Exit();
        }
        // Change to new state
        activeState = newState;

        // Fail-safe null check to make sure new state wasn't null
        if (activeState != null)
        {
            // Setup new state.
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();

        }
    }
}
