using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // class designed to spawn our minions on the line
    [SerializeField]
    private GameObject minion;
    private readonly int radius = 5;

    private void Start()
    {
        
    }

    private void SpawnMinion()
    {
        Vector3 position = new Vector3(transform.position.x + Random.Range(0, radius),
                transform.position.y,
                transform.position.z + Random.Range(0, radius));
        GameObject newMinion = Instantiate(minion, position, Quaternion.identity);
    }

    private void SetMinion(GameObject minion)
    {
        this.minion = minion;
    }
}
