using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    [SerializeField]
    private float _minX;
    [SerializeField]
    private float _maxX;

    private Transform _playerTransform;
    private Vector3 _tempos;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        _tempos = transform.position;
        _tempos.x = _playerTransform.position.x;
        _tempos.x = _tempos.x < _minX ? _minX : _tempos.x;
        _tempos.x = _tempos.x > _maxX ? _maxX : _tempos.x;
        transform.position = _tempos;
    }
}
