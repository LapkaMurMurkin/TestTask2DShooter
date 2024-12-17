using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;

    private float _spawnDelay;

    public void Initialize()
    {
        _spawnDelay = 5;
    }

    private void Update()
    {
        _spawnDelay -= Time.deltaTime;
        if (_spawnDelay <= 0)
        {
            SpawnZombie();
            _spawnDelay = Random.Range(1, 10);
        }
    }

    private void SpawnZombie()
    {
        float faceDirection = Random.Range(0, 2) * 2 - 1;
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(faceDirection * 1.1f, 0, 10));
        spawnPosition.y = 0;
        int zombieTypeIndex = Random.Range(0, _prefabs.Count);
        
        GameObject prefab = Instantiate(_prefabs[zombieTypeIndex], spawnPosition, new Quaternion(), transform);
        Zombie zombie = prefab.GetComponent<Zombie>();
        zombie.Initialize(faceDirection);
    }
}
