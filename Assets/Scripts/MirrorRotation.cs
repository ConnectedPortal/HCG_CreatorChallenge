using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotation : MonoBehaviour
{
    private Animator animator;
    private bool isRotated = false;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void RotateMirror()
    {
        if (!isRotated)
        {
            animator.SetBool("ButtonPress", true);
            isRotated = true;
        }
        else
        {
            animator.SetBool("ButtonPress", false);
            isRotated = false;
        }
    }
}
