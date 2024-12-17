using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _direction;
    [SerializeField] private float _movementSpeed;

    [SerializeField] private float _lifeTime;
    private float _timer;

    public static Action<Bullet> OnDeactivate;

    public void Initialize()
    {
        _timer = _lifeTime;
    }

    private void Update()
    {
        transform.Translate(new Vector3(_direction * _movementSpeed * Time.deltaTime, 0, 0));

        _timer -= Time.deltaTime;

        if (_timer <= 0)
            Deactivate();
    }

    public void Activate(Vector3 position, float direction)
    {
        gameObject.SetActive(true);
        _direction = direction;
        transform.position = position;
        transform.localScale = new Vector3(_direction, 1, 1);
    }

    public void Deactivate()
    {
        _timer = _lifeTime;
        gameObject.SetActive(false);
        OnDeactivate?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Zombie zombie = collider.gameObject.GetComponent<Zombie>();
        if (zombie is not null)
        {
            zombie.ApplyDamage(1);
            Deactivate();
        }
    }
}
