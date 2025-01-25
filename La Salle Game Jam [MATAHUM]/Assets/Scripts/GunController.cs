using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Projectile Properties")]
    [SerializeField] GameObject projectilePrefab; 
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootForce;
    [Header("Projectile Type")]
    public bool isSelectBubble;
    public bool canPressKeys;
    public string bubbleSequence = ""; // Stores the sequence of key presses
    private int maxLength = 3;
    public int bubbleTeaLayers;
    public GameObject[] bubbleTeaLayersObj;

    [Header("Materials for Each Layer")]
    public Material[] element1Materials; 
    public Material[] element2Materials; 
    public Material[] element3Materials; 
    public Material[] element4Materials; 
    public Material[] element5Materials; 
    public Material[] element6Materials; 


    [Header("Player Animators")]
    [SerializeField] Animator _playerAnimator;
    public Animator _ammoAnimator;
    public Animator _blueButtonAnimator;
    public Animator _redButtonAnimator;
    public Animator _greenButtonAnimator;
    public Animator _purpleButtonAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _ammoAnimator.speed = 2.0f;
        _blueButtonAnimator.speed = 1.5f;
        _redButtonAnimator.speed = 1.5f;
        _greenButtonAnimator.speed = 1.5f;
        _purpleButtonAnimator.speed = 1.5f;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSelectBubble == true)
        {
            _playerAnimator.speed = 1.5f;
            _playerAnimator.SetInteger("animState", 1); // Shoot() is called in the event system
            _ammoAnimator.SetInteger("animState", 1);
            canPressKeys = false;
        }
        else
        {
            Debug.Log("No Ingredient Selected");
        }
        // Bubble Selector =========================
        if (canPressKeys == true)
        {
             if (Input.GetKeyDown(KeyCode.Q))
            {
                AddToBubbleSequence("1");
                isSelectBubble = true;
                _blueButtonAnimator.SetInteger("animState", 1);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                AddToBubbleSequence("2");
                isSelectBubble = true;
                _redButtonAnimator.SetInteger("animState", 1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddToBubbleSequence("3");
                isSelectBubble = true;
                _greenButtonAnimator.SetInteger("animState", 1);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                AddToBubbleSequence("4");
                isSelectBubble = true;
                _purpleButtonAnimator.SetInteger("animState", 1);
            }
        }

        // Bubble Tea Layers =========================
 switch (bubbleSequence.Length)
    {
        case 0:
            // No sequence: deactivate all layers
            foreach (GameObject obj in bubbleTeaLayersObj)
            {
                obj.SetActive(false);
            }
            break;

        case 1:
            // Single-layer tea
            bubbleTeaLayersObj[0].SetActive(true); // Activate Element 0
            AssignMaterial(bubbleTeaLayersObj[0], bubbleSequence[0], element1Materials);
            break;

        case 2:
            // Two-layer tea
            bubbleTeaLayersObj[0].SetActive(false); // Deactivate Element 0
            bubbleTeaLayersObj[1].SetActive(true); // Activate Element 1
            bubbleTeaLayersObj[2].SetActive(true); // Activate Element 2
            AssignMaterial(bubbleTeaLayersObj[1], bubbleSequence[0], element2Materials); // First layer
            AssignMaterial(bubbleTeaLayersObj[2], bubbleSequence[1], element3Materials); // Second layer
            break;

        case 3:
            // Three-layer tea
            bubbleTeaLayersObj[0].SetActive(false); // Deactivate Element 0
            bubbleTeaLayersObj[1].SetActive(false); // Deactivate Element 1
            bubbleTeaLayersObj[2].SetActive(false); // Deactivate Element 2
            bubbleTeaLayersObj[3].SetActive(true); // Activate Element 3
            bubbleTeaLayersObj[4].SetActive(true); // Activate Element 4
            bubbleTeaLayersObj[5].SetActive(true); // Activate Element 5
            AssignMaterial(bubbleTeaLayersObj[3], bubbleSequence[0], element4Materials); // First layer
            AssignMaterial(bubbleTeaLayersObj[4], bubbleSequence[1], element5Materials); // Second layer
            AssignMaterial(bubbleTeaLayersObj[5], bubbleSequence[2], element6Materials); // Third layer
            break;
    }
    }
    void AssignMaterial(GameObject layerObj, char sequenceChar, Material[] materials)
    {
        // Map the sequence character to the correct material
        int materialIndex = int.Parse(sequenceChar.ToString()) - 1; // 1 → 0, 2 → 1, etc.
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            Renderer renderer = layerObj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[materialIndex];
            }
            else
            {
                Debug.LogError($"Renderer not found on {layerObj.name}");
            }
        }
        else
        {
            Debug.LogError($"Invalid sequence character: {sequenceChar}");
        }
    }
    public void Shoot()
    {
        isSelectBubble = false;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Set the projectile sequence
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.projectileSequence = bubbleSequence; // Pass the sequence to the projectile
        }

        // Apply force to the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.up * shootForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody not found on the projectile!");
        }

        // Reset the sequence after shooting
        bubbleSequence = "";
    }

    void AddToBubbleSequence(string value)
    {
        if (bubbleSequence.Length < maxLength)
        {
            bubbleSequence += value;
            Debug.Log($"Key Added: {value}, Current Sequence: {bubbleSequence}");
        }
        else
        {
            Debug.Log("Maximum sequence length reached!");
        }
    }
    public void PlayerIdle()
    {
        _playerAnimator.speed = 1;
        _playerAnimator.SetInteger("animState", 0);
    }


}
