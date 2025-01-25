using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAnimator : MonoBehaviour
{
    public GunController _gunController;
    void Start()
    {
        _gunController = FindObjectOfType<GunController>();
    }
    public void AmmoIdle()
    {
        _gunController._ammoAnimator.SetInteger("animState", 0);
        _gunController.canPressKeys = true;
    }
}
