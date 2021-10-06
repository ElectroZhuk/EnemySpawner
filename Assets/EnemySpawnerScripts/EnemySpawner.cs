using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private Vector2[] _points;

    private float _time;
    private int _currentPointIndex;

    private void OnEnable()
    {
        _time = 0;
        _currentPointIndex = 0;
    }

    private void Update()
    {
        if (_time >= _delay)
        {
            SpawnInPoint(_points[_currentPointIndex++]);
            _time = 0;

            if (_currentPointIndex >= _points.Length)
                _currentPointIndex = 0;
        }
        else
        {
            _time += Time.deltaTime;
        }
    }

    private void SpawnInPoint(Vector2 point)
    {
        Instantiate(_enemy, point, Quaternion.identity);
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
