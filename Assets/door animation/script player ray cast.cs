using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour // Descriptive class name
{
    public GameObject crosshair;
    public float interactionDistance;
    public LayerMask interactableLayers; // Clearer variable name

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactableLayers))
        {
            Door door = hit.collider.gameObject.GetComponent<Door>(); // Store the door component
            if (door != null) // Check if the door component exists
            {
                crosshair.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.openClose();
                }
            }
            else // Indicate no door found (optional)
            {
                // Add visual or audio cue (e.g., play a sound effect)
                Debug.Log("Not a door!"); // Log message for debugging
            }
        }
        else
        {
            crosshair.SetActive(false);
        }
    }
}
