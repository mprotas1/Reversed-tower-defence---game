using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionFollowLaneState : MinionBaseState
{
    private Movement movement;

    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("I'm in FollowLane state");
        movement = minion.GetComponent<Movement>();
        //movement.SetIndex(movement.GetIndex() + 1);
        //movement.Move();
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collider other)
    {
    }

    public override void UpdateState(MinionStateManager minion)
    {
        //movement.Move();
    }

}
