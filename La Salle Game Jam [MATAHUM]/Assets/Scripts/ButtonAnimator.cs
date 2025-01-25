using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
    public Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void IdleButton()
    {
        _animator.SetInteger("animState", 0);
    }
}
