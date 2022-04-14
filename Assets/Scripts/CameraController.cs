using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Head").transform;
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
}
