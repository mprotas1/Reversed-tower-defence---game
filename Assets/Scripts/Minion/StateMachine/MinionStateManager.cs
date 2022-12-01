using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStateManager : MonoBehaviour
{
    private MinionBaseState CurrentState;
    public MinionFollowLaneState FollowLaneState;
    public MinionAttackingState AttackState;
    public MinionDeadState DeadState;

    public GameObject LockedEnemy;

    void Start()
    {
        // initializing states of minion
        FollowLaneState = new MinionFollowLaneState();
        AttackState = new MinionAttackingState();
        DeadState = new MinionDeadState();

        // setting LockedEnemy GO to null
        LockedEnemy = null;

        // a minion at the beggining of it's life follows the line until it spies an enemy tower
        CurrentState = FollowLaneState;

        // reference to the context
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(MinionBaseState state)
    {
        this.CurrentState = state;
        CurrentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower") && LockedEnemy == null)
        {
            LockedEnemy = other.gameObject;
            SwitchState(AttackState);
        }
    }
}
