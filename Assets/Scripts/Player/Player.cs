using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerView _view;

    private float _faceDirection;
    [SerializeField] private int _ammoCount;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private BulletPool _bulletPool;

    private InputAction _movement;
    private InputAction _fire;

    [SerializeField] private Animator _bodyAnimator;
    [SerializeField] private Animator _legsAnimator;

    private PlayerBodyAnimatorController _bodyAnimatorController;
    private PlayerLegsAnimatorController _legsAnimatorController;

    private AnimatorEvents _animatorEvents;

    private SoundEffects _soundEffects;

    public void Initialize()
    {
        _view = GetComponent<PlayerView>();
        _view.Initialize(_ammoCount);

        _faceDirection = transform.localScale.x;
        _bulletPool.Initialize();
        
        ActionMap actionMap = ServiceLocator.Get<ActionMap>();
        _movement = actionMap.Player.Movement;
        _fire = actionMap.Player.Fire;
        
        _bodyAnimatorController = new PlayerBodyAnimatorController(_bodyAnimator);
        _legsAnimatorController = new PlayerLegsAnimatorController(_legsAnimator);

        _animatorEvents = GetComponentInChildren<AnimatorEvents>();
        
        _soundEffects = ServiceLocator.Get<SoundEffects>();

        _animatorEvents.OnShot += TakeShot;
    }

    private void OnDestroy()
    {
        _animatorEvents.OnShot -= TakeShot;
    }

    public void Update()
    {
        ListenMoveInput();
        ListenFireInput();
    }

    private void ListenMoveInput()
    {
        float movementDirection = _movement.ReadValue<float>();

        if (movementDirection is not 0)
        {
            _faceDirection = movementDirection;
            transform.localScale = new Vector3(_faceDirection, 1, 1);
            _legsAnimatorController.SwitchAnimationTo(PlayerLegsAnimatorController.RUN_ANIM_NAME, 0);
        }
        else
        {
            _legsAnimatorController.SwitchAnimationTo(PlayerLegsAnimatorController.IDLE_ANIM_NAME, 0);
        }

        transform.Translate(new Vector3(movementDirection * _movementSpeed * Time.deltaTime, 0, 0));
    }

    private void ListenFireInput()
    {
        if (_fire.phase is InputActionPhase.Performed)
            _bodyAnimatorController.SwitchAnimationTo(PlayerBodyAnimatorController.FIRE_ANIM_NAME);
        else
            _bodyAnimatorController.SwitchAnimationTo(PlayerBodyAnimatorController.IDLE_ANIM_NAME);
    }

    private void TakeShot()
    {
        _ammoCount -= 1;
        _view.UpdateAmmoCount(_ammoCount);
        _bulletPool.SpawnBullet(_faceDirection);
        _soundEffects.PlaySoundEffect(SoundEffectID.SHOT);

        if (_ammoCount <= 0)
            Die();
    }

    private void Die()
    {
        _movement.Disable();
        _fire.Disable();
        _view.ActivateDeathScreen();
        _soundEffects.PlaySoundEffect(SoundEffectID.DEATH);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Zombie zombie = collider.gameObject.GetComponent<Zombie>();
        if (zombie is not null)
        {
            Die();
            return;
        }

        AmmoStack ammoStack = collider.gameObject.GetComponent<AmmoStack>();
        if (ammoStack is not null)
        {
            _ammoCount += ammoStack.AmmoCount;
            _view.UpdateAmmoCount(_ammoCount);
            Destroy(ammoStack.gameObject);
            _soundEffects.PlaySoundEffect(SoundEffectID.LOOT);
        }
    }
}
