using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorInteraction : MonoBehaviour
{
    public Transform door; // Assign the actual door transform
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public InputActionReference openAction; // Reference to your input action (e.g., trigger)

    private bool isPlayerNearby = false;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        closedRotation = door.rotation;
        openRotation = Quaternion.Euler(door.eulerAngles + new Vector3(0, openAngle, 0));

        if (openAction != null)
        {
            openAction.action.performed += OnOpenAction;
        }
    }

    private void OnDestroy()
    {
        if (openAction != null)
        {
            openAction.action.performed -= OnOpenAction;
        }
    }

    private void Update()
    {
        if (isOpen)
            door.rotation = Quaternion.Slerp(door.rotation, openRotation, Time.deltaTime * openSpeed);
        else
            door.rotation = Quaternion.Slerp(door.rotation, closedRotation, Time.deltaTime * openSpeed);
    }

    private void OnOpenAction(InputAction.CallbackContext context)
    {
        if (isPlayerNearby)
        {
            isOpen = !isOpen;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Hand")) // Adjust tag as needed
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Hand"))
        {
            isPlayerNearby = false;
        }
    }
}
