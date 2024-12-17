using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoStack : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoCountText;
    public int AmmoCount { get; private set; }

    public void Initialize()
    {
        AmmoCount = Random.Range(1, 10); ;
        _ammoCountText.text = AmmoCount.ToString();
    }
}
