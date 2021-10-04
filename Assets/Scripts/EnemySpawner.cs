using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemy;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void Spawn()
    {
        float spawnPointX = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float spawnPointY = Random.Range(_collider.bounds.min.y, _collider.bounds.max.y);
        float spawnPointZ = 0;
        Instantiate(_enemy, new Vector3(spawnPointX, spawnPointY, spawnPointZ), Quaternion.identity);
    }
}
