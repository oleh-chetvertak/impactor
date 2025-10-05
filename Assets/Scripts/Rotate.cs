using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 _rotation;
    private const float _speed = 1f;

    void Update()
    {
        _rotation = Vector3.up;
        transform.Rotate(_speed * Time.deltaTime * _rotation);
        _rotation = Vector3.left;
        transform.Rotate(_speed * Time.deltaTime * _rotation);
    }
}
