using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _loot;
    [SerializeField]
    private AudioClip _shot;
    [SerializeField]
    private AudioClip _kill;
    [SerializeField]
    private AudioClip _death;

    private Dictionary<SoundEffectID, AudioClip> _sounds;

    public void Initialize()
    {
        _sounds = new Dictionary<SoundEffectID, AudioClip>{
            {SoundEffectID.LOOT, _loot},
            {SoundEffectID.SHOT, _shot},
            {SoundEffectID.KILL, _kill},
            {SoundEffectID.DEATH, _death}
        };
    }

    public void PlaySoundEffect(SoundEffectID ID)
    {
        _audioSource.clip = _sounds[ID];
        _audioSource.Play();
    }

}

public enum SoundEffectID
{
    LOOT,
    SHOT,
    KILL,
    DEATH
}
