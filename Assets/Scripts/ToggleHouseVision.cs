using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHouseVision : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] float _targetAlpha;

    private Player _player;
    private float _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _player))
        {
            _target = _targetAlpha;
            StartCoroutine(ChangeAlpha());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _player))
        {
            _target = 1;
            StartCoroutine(ChangeAlpha());
        }
    }

    private IEnumerator ChangeAlpha()
    {
        while (_renderer.color.a != _target)
        {
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, Mathf.MoveTowards(_renderer.color.a, _target, 0.1f));

            yield return null;
        }
    }
}
