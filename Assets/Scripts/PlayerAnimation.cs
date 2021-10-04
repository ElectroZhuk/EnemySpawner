using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private float _lastPositionX;

    private void Awake()
    {
        _lastPositionX = transform.position.x;
    }

    private void FixedUpdate()
    {
        if (transform.position.x > _lastPositionX)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            _animator.Play("PlayerRun");
            _lastPositionX = transform.position.x;
        }
        else if (transform.position.x < _lastPositionX)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            _animator.Play("PlayerRun");
            _lastPositionX = transform.position.x;
        }
        else
        {
            _animator.Play("PlayerIdle");
        }
    }
}
