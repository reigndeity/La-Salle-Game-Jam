using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class OutlineUi : MonoBehaviour
{
    public Material defaultMaterial;  // Normal material
    public Material outlineMaterial;  // Material for outline

    private TextMeshPro textMeshPro;  // Reference to TextMeshPro component

    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();  // Get the TextMeshPro component
        // Ensure the text starts with the default material
        textMeshPro.fontMaterial = defaultMaterial;
    }

    void OnMouseEnter()
    {
        // When the mouse enters, change to the outline material
        textMeshPro.fontMaterial = outlineMaterial;
    }

    void OnMouseExit()
    {
        // When the mouse exits, revert to the default material
        textMeshPro.fontMaterial = defaultMaterial;
    }
}
