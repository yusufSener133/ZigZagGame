using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject _target;
    Vector3 _distance;
    void Start()
    {
        _distance = transform.position - _target.transform.position;
    }

    void LateUpdate()
    {
        transform.position = _target.transform.position + _distance;
    }
}
