using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorWalk : MonoBehaviour, IPlayerBehavior
{
    [SerializeField]
    private Animation anim;

    public void EnterBehavior()
    {
        anim.Play();
    }

    public void ExitBehavior()
    {
        anim.Stop();
    }
}
