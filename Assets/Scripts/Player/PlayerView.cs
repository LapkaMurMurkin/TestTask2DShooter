using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ammoCount;
    private DeathScreen _deathScreen;

    public void Initialize(int ammoCount)
    {
        UpdateAmmoCount(ammoCount);
        _deathScreen = ServiceLocator.Get<DeathScreen>();
    }

    public void UpdateAmmoCount(int ammoCount)
    {
        _ammoCount.text = $"Ammo {ammoCount.ToString()}";
    }

    public void ActivateDeathScreen()
    {
        _deathScreen.Activate();
    }
}
