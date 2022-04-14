using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private SpikesCollider SC;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 checkpointPos;

    void Start()
    {
        checkpointPos = player.transform.position;
        Debug.Log("SETPOS: " + checkpointPos);
    }

    public void setPlayerPosition(){
        player.transform.position = checkpointPos;
    }

    public void SetNewCheckpoint(Vector3 position){
        checkpointPos = position;
        Debug.Log("New checkpoint position: " + checkpointPos);
    }
}
