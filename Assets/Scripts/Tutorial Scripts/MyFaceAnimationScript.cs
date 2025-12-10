using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFaceAnimationScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float coolDownTime = 1.75f;
    public void PlayClip() 
    {
        animator.speed = 1;
    }
    public void StopClip() 
    {
        animator.speed = 0;
    }
    public void AnimationCoroutine() 
    {
        StartCoroutine(AnimationCoolDown());
    }
    IEnumerator AnimationCoolDown() 
    {
        StopClip();
        yield return new WaitForSeconds(coolDownTime);
        PlayClip();
    }
}
