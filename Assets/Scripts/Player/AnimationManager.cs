using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    Animation anim;

    [SerializeField]
    AnimationClip[] clips;

    [SerializeField]
    GameObject sword;

    private void Start()
    {
        if(anim == null)
        anim = gameObject.GetComponent<Animation>();

        if(sword == null)
        sword = gameObject.transform.Find("Sword").gameObject;
        sword.SetActive(false);
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
            sword.SetActive(true);
            anim.Play(clips[2].name);
            return;
        }
        else
        {
            //sword.SetActive(false);
        }
            //anim.Play(clips[0].name);
    }
}
