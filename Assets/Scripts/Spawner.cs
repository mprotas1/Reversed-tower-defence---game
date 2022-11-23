using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // class designed to spawn our minions on the line
    [SerializeField]
    private GameObject minion;
    private readonly float period = 2.0f;
    private float time = 0.0f;
    private readonly int radius = 5;

    // Update is called once per frame
    void Update()
    {
        // here I'm spawning minion every "period" time but in future
        // it's gonna be spawning after clicking on GUI which minion should be spawned
        SpawnMinion();
    }

    private void SpawnMinion()
    {
        time += Time.deltaTime;
        if (time >= period)
        {
            time = 0.0f;
            Vector3 position = new Vector3(transform.position.x + Random.Range(0, radius),
                transform.position.y,
                transform.position.z + Random.Range(0, radius));
            GameObject newMinion = Instantiate(minion, position, Quaternion.identity);
        }
    }
}
