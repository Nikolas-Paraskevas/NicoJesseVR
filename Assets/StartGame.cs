using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    public InputActionReference startAction; // Link this to a controller button

    private void OnEnable()
    {
        startAction.action.performed += OnStartPressed;
        startAction.action.Enable();
    }

    private void OnDisable()
    {
        startAction.action.performed -= OnStartPressed;
        startAction.action.Disable();
    }

    private void OnStartPressed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("mainscenevr"); // Replace with your scene name
    }
}
