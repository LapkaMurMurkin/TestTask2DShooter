using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieView : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public void Initialize(int maxHealth)
    {
        _healthBar.minValue = 0;
        _healthBar.maxValue = maxHealth;
        _healthBar.value = _healthBar.maxValue;
    }

    public void UpdateHeathBar(int health)
    {
        _healthBar.value = health;
    }
}
