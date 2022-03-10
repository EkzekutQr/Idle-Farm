using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    Animation anim;

    [SerializeField]
    AnimationClip[] clips;

    private void Start()
    {
        if(anim == null)
        anim = gameObject.GetComponent<Animation>();
    }

    private void FixedUpdate()
    {
        AnimationSwitch();
    }

    private void AnimationSwitch()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.Play(clips[1].name);
            return;
        }
        if (Input.GetKey(KeyCode.E))
        {
            anim.Play(clips[2].name);
            return;
        }
            anim.Play(clips[0].name);
    }
}
