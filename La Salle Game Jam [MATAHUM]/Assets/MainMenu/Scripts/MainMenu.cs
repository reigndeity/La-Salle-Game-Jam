using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public LayerMask playLayer;
    public LayerMask exitLayer;
    public LayerMask bellLayer;

    public Animator bellAnimator;
    public Animator doorAnimator;
    public Animator camAnimator;
    public Animator fadeAnimator;

    public BoxCollider startCollider;
    public BoxCollider exitCollider;

    public GameObject helpButton;

    private void Start()
    {
        startCollider.enabled = true;
        exitCollider.enabled = true;
        Time.timeScale = 1;
        Cursor.visible = true;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, playLayer))
            {
                Debug.Log("Open");
                AudioManager.instance.OnButtonClickSFX();

                startCollider.enabled = false;
                exitCollider.enabled = false;

                helpButton.SetActive(false);

                camAnimator.SetTrigger("OpenDoor");
                //fadeAnimator.SetTrigger("FadeOut"); 
                doorAnimator.SetTrigger("OpenDoor");
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, exitLayer))
            {
                AudioManager.instance.OnButtonClickSFX();
                Debug.Log("Exit");
                Application.Quit();
            }
            else if(Physics.Raycast(ray, out hit, Mathf.Infinity, bellLayer))
            {
                bellAnimator.SetTrigger("RingBell");
                AudioManager.instance.OnBellClickSFX();
                Debug.Log("Ring");
            }
        }
    }

    public void TriggerFade() 
    {
        fadeAnimator.SetTrigger("FadeOut");
    }
}
