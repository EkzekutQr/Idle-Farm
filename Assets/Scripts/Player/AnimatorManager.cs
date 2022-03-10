using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject sword;

    private void Update()
    {
        AnimationSwitch();
        SwordActivator();
    }
    private void AnimationSwitch()
    {
        animator.SetBool("SlowRun", false);
        animator.SetBool("Harvest", false);

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && Input.GetKey(KeyCode.E))
        {
            animator.SetBool("SlowRun", true);
            animator.SetBool("Harvest", true);
            return;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("SlowRun", true);
            return;
        }

        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Harvest", true);
            return;
        }
    }
    private void SwordActivator()
    {
        if (animator.GetBool("Harvest"))
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }
    }
}
