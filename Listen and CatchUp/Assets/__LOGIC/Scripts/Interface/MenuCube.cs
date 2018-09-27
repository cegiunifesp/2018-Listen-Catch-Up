using System;
using UnityEngine;

public class MenuCube : MonoBehaviour
{

    public Action<MenuCube> OnClicked;
    public Animator TextAnimator;


    protected virtual void OnMouseEnter()
    {
        TextAnimator.SetBool("Visible", true);
    }

    protected virtual void OnMouseExit()
    {
        TextAnimator.SetBool("Visible", false);
    }

    protected virtual void OnMouseDown()
    {
        OnClicked?.Invoke(this);
        Destroy(gameObject);
    }
}
