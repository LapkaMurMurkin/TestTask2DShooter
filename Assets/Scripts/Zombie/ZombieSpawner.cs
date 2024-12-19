using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    //[SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private Zombie _zombiePrefab;
    [SerializeField] private List<ZombieSettings> _zombieTypes;

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
        int zombieType = Random.Range(0, _zombieTypes.Count);

        Zombie zombie = Instantiate(_zombiePrefab, spawnPosition, new Quaternion(), transform);
        zombie.Initialize(_zombieTypes[zombieType], faceDirection);
    }
}
