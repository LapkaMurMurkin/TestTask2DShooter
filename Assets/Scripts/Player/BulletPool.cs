using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _bulletPoint;
    private List<Bullet> _activeObjects;
    private List<Bullet> _inactiveObjects;

    public void Initialize()
    {
        _activeObjects = new List<Bullet>();
        _inactiveObjects = new List<Bullet>();

        Bullet.OnDeactivate += DeactivateBullet;
    }

    private void OnDestroy()
    {
        Bullet.OnDeactivate -= DeactivateBullet;
    }

    public void SpawnBullet(float direction)
    {
        if (_inactiveObjects.Count is 0)
        {
            GameObject prefab = Instantiate(_prefab, _bulletPoint.position, new Quaternion(), transform);
            Bullet bullet = prefab.GetComponent<Bullet>();
            bullet.Initialize();
            bullet.Activate(_bulletPoint.position, direction);

            _activeObjects.Add(bullet);
        }
        else
        {
            Bullet bullet = _inactiveObjects[0];
            _inactiveObjects.Remove(bullet);
            _activeObjects.Add(bullet);
            bullet.Activate(_bulletPoint.position, direction);
        }
    }

    public void DeactivateBullet(Bullet bullet)
    {
        _activeObjects.Remove(bullet);
        _inactiveObjects.Add(bullet);
    }
}
