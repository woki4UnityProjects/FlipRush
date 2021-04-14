using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 playerPos;
    private Vector3 cameraPos;
    private float offsetX;
    private float offsetY;
    private float startPosZ;

    private void Awake()
    {
        playerPos = player.position;
        cameraPos = transform.position;
    }

    void Start()
    {
        startPosZ = cameraPos.z;
        offsetX = cameraPos.x - playerPos.x;
        offsetY = cameraPos.y -  playerPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.position;
        transform.position = new Vector3(playerPos.x + offsetX, playerPos.y + offsetY, startPosZ);
    }
}
