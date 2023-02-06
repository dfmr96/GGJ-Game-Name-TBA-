using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    Animation animator;

    private void Start()
    {
        animator = GetComponent<Animation>();
        FadeIn();
    }

    public void FadeIn()
    {
        animator.Play("FadeIn");
    }

    public void FadeOut()
    {
        animator.Play("FadeOut");
    }
}
