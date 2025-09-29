using System.Collections;
using UnityEngine;

public class RoomCreate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoomGenerator.Instance.Create();
        }
    }
}
