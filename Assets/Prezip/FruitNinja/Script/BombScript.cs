using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private float rotationForce = 200;
    void Start()
    {
        transform.rotation = Random.rotation;
    }

    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }
}
