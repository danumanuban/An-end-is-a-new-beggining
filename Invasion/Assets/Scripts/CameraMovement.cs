using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = newPos;
    }

}
