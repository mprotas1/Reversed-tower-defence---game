using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Attack : MonoBehaviour
{
    private GameObject LockedMinion;
    private TowerInstance tower;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        LockedMinion = null;
        tower = GetComponent<TowerInstance>();
        canAttack = true;
    }

    void Update()
    {
        if(LockedMinion != null)
        {
            AttackMinion(LockedMinion.GetComponent<Minion>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            LockedMinion = other.gameObject;
        }
    }

    private void AttackMinion(Minion minion)
    {
        float distance = Vector3.Distance(transform.position,
                           minion.transform.position);
        if(distance <= tower.Range && canAttack)
        {
            Debug.Log(this.name + ": attacking");
            tower.Attack(minion);
            if(minion.IsDead())
            {
                LockedMinion = null;
            }
        }
        StopAllCoroutines();
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds((float)tower.AttackFrequency);
        canAttack = true;
    }
}

