using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public LayerMask playLayer;
    public LayerMask exitLayer;
    public LayerMask bellLayer;

    public Animator bellAnimator;
    public Animator doorAnimator;
    public Animator camAnimator;

    public BoxCollider startCollider;
    public BoxCollider exitCollider;

    private void Start()
    {
        startCollider.enabled = true;
        exitCollider.enabled = true;
    }

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast, but only for the specified LayerMask
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, playLayer))
            {
                Debug.Log("Open");
                AudioManager.instance.OnButtonClickSFX();
                startCollider.enabled = false;
                exitCollider.enabled = false;
                doorAnimator.SetTrigger("OpenDoor");
                camAnimator.SetTrigger("OpenDoor");
            } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, exitLayer))
            {
                AudioManager.instance.OnButtonClickSFX();
                Debug.Log("Exit");
                Application.Quit();
            } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, bellLayer))
            {
                bellAnimator.SetTrigger("RingBell");
                AudioManager.instance.OnBellClickSFX();
                Debug.Log("Ring");
            }
        }
    }
}
