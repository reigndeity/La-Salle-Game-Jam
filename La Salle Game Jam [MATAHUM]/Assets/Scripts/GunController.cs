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
    public string bubbleSequence = ""; // Stores the sequence of key presses
    private int maxLength = 3;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSelectBubble == true)
        {
            Shoot();
        }
        else
        {
            Debug.Log("No Ingredient Selected");
        }

        // Bubble Selector =========================
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddToBubbleSequence("1");
            isSelectBubble = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddToBubbleSequence("2");
            isSelectBubble = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddToBubbleSequence("3");
            isSelectBubble = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddToBubbleSequence("4");
            isSelectBubble = true;
        }

        // Debug output for testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Current Sequence: {bubbleSequence}");
        }
    }

    void Shoot()
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
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
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
}
