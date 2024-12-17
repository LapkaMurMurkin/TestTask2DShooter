using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    public Action OnAnimationStart;
    private void AnimationStartEvent() => OnAnimationStart?.Invoke();

    public Action OnAnimationEnd;
    private void AnimationEndEvent() => OnAnimationEnd?.Invoke();

    public Action OnShot;
    private void ShotEvent() => OnShot?.Invoke();
}
