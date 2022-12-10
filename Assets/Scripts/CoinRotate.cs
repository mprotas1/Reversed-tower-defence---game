using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField]
    private int RotationFrequency = 50;

    private Vector3 rotationVector;

    private void Start()
    {
        rotationVector = new Vector3(15, 0, 5).normalized;
    }

    void Update()
    {
        // rotate coin each frame
        transform.Rotate(rotationVector * RotationFrequency * Time.deltaTime, Space.Self);
    }
}
