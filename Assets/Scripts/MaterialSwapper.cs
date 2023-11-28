using UnityEngine;

//ChatGPT
public class MaterialSwapper : MonoBehaviour
{
    public Material[] materials; // array of materials to swap
    public Renderer rend; // the renderer component of the object

    private int currentMaterialIndex = 0; // current material index

    void Start()
    {
        // get the renderer component
        rend = GetComponent<Renderer>();
        // set the initial material
        rend.material = materials[currentMaterialIndex];
    }

    void Update()
    {
        // check if the mouse scroll has been used
        if (Input.mouseScrollDelta.y != 0)
        {
            // increment/decrement the current material index based on the scroll direction
            currentMaterialIndex += (int)Mathf.Sign(Input.mouseScrollDelta.y);

            // loop back to the beginning of the array if we've reached the end
            if (currentMaterialIndex >= materials.Length)
            {
                currentMaterialIndex = 0;
            }
            else if (currentMaterialIndex < 0)
            {
                currentMaterialIndex = materials.Length - 1;
            }

            // swap the material on the object
            rend.material = materials[currentMaterialIndex];
        }
    }
}