using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemFirstSelected : MonoBehaviour
{
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
