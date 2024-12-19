using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private ZombieSettings _zombieSettings;
    private ZombieView _view;


    private float _faceDirection;
    private int _health;
    private float _movementSpeed;

    private Animator _animator;

    public static Action<Vector3> OnDeath;

    private void Update()
    {
        transform.Translate(new Vector3(-_faceDirection * _movementSpeed * Time.deltaTime, 0, 0));
    }

    public void Initialize(ZombieSettings zombieSettings, float faceDirection)
    {
        _zombieSettings = zombieSettings;

        _health = _zombieSettings.Health;
        _movementSpeed = _zombieSettings.MovementSpeed;

        _animator = GetComponentInChildren<Animator>();
        AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
        List<KeyValuePair<AnimationClip, AnimationClip>> overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        overrides.Add(new KeyValuePair<AnimationClip, AnimationClip>(animatorOverrideController.animationClips[0], _zombieSettings.AnimationClip));
        animatorOverrideController.ApplyOverrides(overrides);
        _animator.runtimeAnimatorController = animatorOverrideController;

        _view = GetComponent<ZombieView>();
        _view.Initialize(_health);

        _faceDirection = faceDirection;
        transform.localScale = new Vector3(-_faceDirection, 1, 1);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        _view.UpdateHeathBar(_health);

        if (_health <= 0)
        {
            OnDeath?.Invoke(transform.position);
            Destroy(gameObject);
            ServiceLocator.Get<SoundEffects>().PlaySoundEffect(SoundEffectID.KILL);
        }
    }
}
