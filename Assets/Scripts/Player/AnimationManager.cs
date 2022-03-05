using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animation anim;

    private void Start()
    {
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
            anim.Play(anim.GetClip("SlowRun").name);
        }
        else
        {
            anim.Play(anim.GetClip("HappyIdle").name);
        }
    }
}
