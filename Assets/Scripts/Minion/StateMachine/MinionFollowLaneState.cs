using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFollowLaneState : MinionBaseState
{
    private Movement movement;

    public override void EnterState(MinionStateManager minion)
    {
        movement = minion.GetComponent<Movement>();
        movement.Move();
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collider other)
    {
        if(other.CompareTag("Tower"))
        {
            minion.SwitchState(minion.AttackState);
        }
    }

    public override void UpdateState(MinionStateManager minion)
    {
        movement.Move();
    }

}
