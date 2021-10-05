using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyEnemySpawners : MonoBehaviour
{
    [SerializeField] private float _delay;

    private EnemySpawner[] _spawners;
    private int _index;
    private float _time;

    private void Start()
    {
        _spawners = GetComponentsInChildren<EnemySpawner>();
        _time = _delay;
    }

    private void FixedUpdate()
    {
        _time += Time.deltaTime;

        if (_time >= _delay)
        {
            _spawners[_index++].Spawn();

            if (_index >= _spawners.Length)
                _index = 0;

            _time = 0;
        }
    }
}
