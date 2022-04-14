using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour
{
    private float rotation_speed;
    void Start()
    {
        rotation_speed = 50f;
    }

    void Update()
    {
         transform.Rotate(Vector3.up *rotation_speed * Time.deltaTime);
    }
}
