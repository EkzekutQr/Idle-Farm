using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorIdle : MonoBehaviour, IPlayerBehavior
{
    [SerializeField]
    private AnimationClip animClip;

    public void EnterBehavior()
    {
        Animation anim = new Animation();
        anim.Play(animClip.name);
    }

    public void ExitBehavior()
    {
    }
}
