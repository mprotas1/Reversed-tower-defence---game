using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFollowLaneState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        minion.movement.Move();
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collider other)
    {
        if(other.tag == "Tower")
        {
            minion.SwitchState(minion.AttackState);
        }
    }

    public override void UpdateState(MinionStateManager minion)
    {
        minion.movement.Move();
    }

}
