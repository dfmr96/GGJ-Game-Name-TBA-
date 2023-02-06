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

    void FadeIn()
    {
        animator.Play("FadeIn");
    }

    void FadeOut()
    {
        animator.Play("FadeOut");
    }
}
