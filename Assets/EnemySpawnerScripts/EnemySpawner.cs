using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private Vector2[] _points;

    private List<Coroutine> _coroutines;

    private void OnEnable()
    {
        _coroutines = new List<Coroutine>();
        _coroutines.Add(StartCoroutine(Spawn()));
    }

    private void OnDisable()
    {
        foreach (var coroutine in _coroutines)
            StopCoroutine(coroutine);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            foreach (var point in _points)
            {
                Instantiate(_enemy, point, Quaternion.identity);

                yield return new WaitForSeconds(_delay);
            }
        }
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
