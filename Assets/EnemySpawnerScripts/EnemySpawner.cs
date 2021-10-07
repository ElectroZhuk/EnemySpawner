using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private Vector2[] _points;

    private bool _isSpawning;

    private void OnEnable()
    {
        _isSpawning = false;
    }

    private void Update()
    {
        if (_isSpawning == false)
            StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _isSpawning = true;

        foreach (var point in _points)
        {
            Instantiate(_enemy, point, Quaternion.identity);

            yield return new WaitForSeconds(_delay);
        }

        _isSpawning = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach (var point in _points)
        {
            Gizmos.DrawSphere(point, 0.2f);
        }
    }
}
