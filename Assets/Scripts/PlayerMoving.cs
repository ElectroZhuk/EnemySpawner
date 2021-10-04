using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(_speed * Time.deltaTime * 1, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(_speed * Time.deltaTime * -1, 0));
        }
    }
}
