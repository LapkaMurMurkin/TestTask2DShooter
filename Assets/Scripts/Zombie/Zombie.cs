using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private ZombieView _view;

    private float _faceDirection;
    [SerializeField] private int _health;
    [SerializeField] private float _movementSpeed;

    public static Action<Vector3> OnDeath;

    private void Update()
    {
        transform.Translate(new Vector3(-_faceDirection * _movementSpeed * Time.deltaTime, 0, 0));
    }

    public void Initialize(float faceDirection)
    {
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
