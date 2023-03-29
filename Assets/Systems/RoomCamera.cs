using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomCamera : MonoBehaviour
{
    public GameObject virtCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            virtCam.SetActive(true);
            CinemachineVirtualCamera vcam;
            vcam = FindObjectOfType<CinemachineVirtualCamera>();
            vcam.Follow = GameObject.Find("Player").transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtCam.SetActive(false);
        }
    }
}
