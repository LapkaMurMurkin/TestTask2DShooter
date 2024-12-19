using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieSettings", menuName = "ScriptableObjects/ZombieSettings")]
public class ZombieSettings : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField]
    private AnimationClip _animationClip;
    public AnimationClip AnimationClip => _animationClip;

    [SerializeField]
    private int _health;
    public int Health => _health;

    [SerializeField]
    private int _movementSpeed;
    public int MovementSpeed => _movementSpeed;

}
