using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviorManager : MonoBehaviour
{
    //List<IPlayerBehavior> behaviors;
    private Dictionary<Type, IPlayerBehavior> behaviors;

    private IPlayerBehavior currentBehavior;


    private void Start()
    {
        InitBehaviors();

        SetDefaultBehavior();
    }

    private void InitBehaviors()
    {
        behaviors = new Dictionary<Type, IPlayerBehavior>();


        behaviors[typeof(PlayerBehaviorIdle)] = new PlayerBehaviorIdle();

        behaviors[typeof(PlayerBehaviorWalk)] = new PlayerBehaviorWalk();
    }

    private void SetBehavior(IPlayerBehavior newBehavior)
    {
        if(currentBehavior != null)
        {
            currentBehavior.ExitBehavior();
        }


        currentBehavior = newBehavior;

        currentBehavior.EnterBehavior();
    }

    private void SetDefaultBehavior()
    {
        var behaviorDefault = GetBehavior<PlayerBehaviorIdle>();

        SetBehavior(behaviorDefault);
    }

    private IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior
    {
        var type = typeof(T);

        return behaviors[type];
    }
}
