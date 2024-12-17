using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneLoader : MonoBehaviour
{
    public static ServiceLocator ServiceLocator = new ServiceLocator();

    private ActionMap _actionMap;
    private Player _player;
    private PlayerCamera _playerCamera;

    private LootSpawner _lootSpawner;
    private DeathScreen _deathScreen;
    private SoundEffects _soundEffects;

    void Awake()
    {
        ServiceLocator = new ServiceLocator();

        _actionMap = new ActionMap();
        _actionMap.Enable();
        ServiceLocator.Register<ActionMap>(_actionMap);

        _lootSpawner = FindFirstObjectByType<LootSpawner>();
        _lootSpawner.Initialize();
        ServiceLocator.Register<LootSpawner>(_lootSpawner);

        _deathScreen = FindFirstObjectByType<DeathScreen>(FindObjectsInactive.Include);
        _deathScreen.Initialize();
        ServiceLocator.Register<DeathScreen>(_deathScreen);

        _soundEffects = FindFirstObjectByType<SoundEffects>(FindObjectsInactive.Include);
        _soundEffects.Initialize();
        ServiceLocator.Register<SoundEffects>(_soundEffects);

        _player = FindFirstObjectByType<Player>();
        _player.Initialize();
        ServiceLocator.Register<Player>(_player);

        _playerCamera = FindFirstObjectByType<PlayerCamera>();
        _playerCamera.Initialize(_player.transform);
        ServiceLocator.Register<PlayerCamera>(_playerCamera);
    }
}
