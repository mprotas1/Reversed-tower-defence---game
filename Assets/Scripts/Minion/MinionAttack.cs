using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAttack : MonoBehaviour
{
    private Minion minion;
    private NavMeshAgent agent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        minion = GetComponent<Minion>();
        animator = GetComponent<Animator>();
    }

    public void AttackTower(Tower tower)
    {
        // stop NavMeshAgent
        agent.Stop();

        // implement animation
        //animator.Play("Attack");

        // handle attacking tower (values)
        minion.Attack(tower);
    }
}
