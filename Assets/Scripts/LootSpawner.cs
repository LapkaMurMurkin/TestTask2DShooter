using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ammoStack;

    public void Initialize()
    {
        Zombie.OnDeath += SpawnLoot;
    }

    private void OnDestroy()
    {
        Zombie.OnDeath -= SpawnLoot;
    }

    public void SpawnLoot(Vector3 position)
    {
        GameObject ammoStackObject = Instantiate(_ammoStack, position, new Quaternion(), transform);
        AmmoStack ammoStackComponent = ammoStackObject.GetComponent<AmmoStack>();
        ammoStackComponent.Initialize();
    }
}
