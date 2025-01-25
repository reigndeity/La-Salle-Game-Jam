using Unity.VisualScripting;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [Header("Mouse Aiming Rotation Limits")]
    [SerializeField] float minYRotation = -30f;
    [SerializeField] float maxYRotation = 30f;

    void Update()
    {
        if (GameManager.Instance.isGameStart == true)
        {
            float mouseX = Input.mousePosition.x / Screen.width;
            float targetYRotation = Mathf.Lerp(minYRotation, maxYRotation, mouseX);
            transform.rotation = Quaternion.Euler(0, targetYRotation, 0f);
        }
        else
        {
            Debug.Log("Can't aim yet!");
        }

    }
}
