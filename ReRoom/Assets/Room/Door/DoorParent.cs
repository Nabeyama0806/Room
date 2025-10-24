using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorParent : MonoBehaviour
{
    public void OpenDoor()
    {
        foreach (Transform door in transform)
        {
            door.GetComponent<DoorController>().CanOpen = true;
        }
    }
}