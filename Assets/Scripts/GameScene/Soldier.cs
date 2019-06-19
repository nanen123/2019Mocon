using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private enum SoldierState
    {
        IDLE,
        RIGHTWARD,
        LEFTWARD
    };

    private Animator anim;
    SoldierState state;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        state = SoldierState.IDLE;
    }

    private void Update()
    {
        anim.SetInteger("Dir", -1);
    }
}
