using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAttack : MonoBehaviour
{
    private Minion minion;
    private NavMeshAgent agent;
    private Animator animator;

    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        minion = GetComponent<Minion>();
        animator = GetComponent<Animator>();

        canAttack = true;
    }

    public void AttackTower(Tower tower)
    {
        if(canAttack)
        {
            // make minion to look at enemy LockedTower tower
            this.transform.LookAt(tower.gameObject.transform);

            agent.stoppingDistance = 0.5f;

            // stop NavMeshAgent
            agent.isStopped = true;

            // implement animation

            // handle attacking tower (values)
            Debug.Log("Attacking");
            //animator.SetTrigger("Attack");
            minion.Attack(tower);
            animator.Play("Attack");

            // delay attacks using AttackFrequency value from Minion
            StopAllCoroutines();
            StartCoroutine(DelayAttack());
        }
        
    }

    private IEnumerator DelayAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds((float) minion.AttackFrequency);
        canAttack = true;
    }
}


