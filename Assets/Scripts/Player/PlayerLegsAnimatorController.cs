using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegsAnimatorController : AnimatorController
{
    public const string IDLE_ANIM_NAME ="legs_idle";
    public const string RUN_ANIM_NAME ="legs_run";

    public PlayerLegsAnimatorController(Animator animator) : base(animator)
    {
    }
}
