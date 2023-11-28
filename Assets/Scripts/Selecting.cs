using UnityEngine;

public class Selecting : MonoBehaviour
{
    //clicks on rocks
    public Camera mainCamera;
    private AudioControllerRevised audioControllerScript;
    


    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Cast a ray from the mouse cursor position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.tag);
            // Check if the hit object has a specific tag (e.g., "SelectableObject")
            if (hit.collider.CompareTag("Selectable"))
            {
                // Log information about the hovered object
                Debug.Log("Hovered over object: " + hit.collider.gameObject.name);

                if (Input.GetMouseButtonDown(0))
                {
                    // Log a message when clicking on the object
                    Debug.Log("Clicked on object: " + hit.collider.gameObject.name);
                    audioControllerScript = hit.collider.gameObject.GetComponent<AudioControllerRevised>();
                    audioControllerScript.ifClicked();
                    audioControllerScript.played = false;
                }
            }
        }
    }
}