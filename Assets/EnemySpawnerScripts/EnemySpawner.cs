using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private Vector2[] _points;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForDelay = new WaitForSeconds(_delay);

        while (true)
        {
            foreach (var point in _points)
            {
                Instantiate(_enemy, point, Quaternion.identity);

                yield return waitForDelay;
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
