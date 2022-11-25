using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStateManager : MonoBehaviour
{
    private MinionBaseState CurrentState;
    public MinionFollowLaneState FollowLaneState = new MinionFollowLaneState();
    public MinionAttackingState AttackState = new MinionAttackingState();
    public MinionDeadState DeadState = new MinionDeadState();

    private GameObject LockedEnemy;
    public Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Tower")
        {
            SwitchState(AttackState);
        }
    }

    public void SwitchState(MinionBaseState state)
    {
        this.CurrentState = state;
        CurrentState.EnterState(this);
    }
}
