using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private InputAction startAction;

    private void OnEnable()
    {
        startAction.performed += OnStart;
        startAction.Enable();
    }

    private void OnDisable()
    {
        startAction.performed -= OnStart;
        startAction.Disable();
    }

    private void OnStart(InputAction.CallbackContext context)
    {
        SceneController.Transition(SceneType.Title, SceneType.Game);
    }
}
