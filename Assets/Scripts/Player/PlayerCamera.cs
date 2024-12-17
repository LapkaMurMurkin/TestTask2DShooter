using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _offset;

    public void Initialize(Transform playerTransform)
    {
        _offset = transform.position;
        _playerTransform = playerTransform;
    }

    private void Update()
    {
        transform.position = _playerTransform.position + _offset;
    }
}
