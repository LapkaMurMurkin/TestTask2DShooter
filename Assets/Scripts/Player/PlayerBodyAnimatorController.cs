using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyAnimatorController : AnimatorController
{
    public const string IDLE_ANIM_NAME ="body_idle";
    public const string FIRE_ANIM_NAME ="body_fire";
    public const string SHOT_ANIM_NAME ="body_single_shot";


    public PlayerBodyAnimatorController(Animator animator) : base(animator)
    {
    }
}
