using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMover : MonoBehaviour
{
    private const string BELT = "Belt";
    private float _meterPerSecond;
    public float MeterPerSecond
    {
        get
        {
            return _meterPerSecond;
        }

        set
        {
            _meterPerSecond = value;
        }
    }

    private void Update()
    {
        MoveBox();
    }

    private void MoveBox()
    {
        Transform belt = GameObject.Find(BELT).transform;
        transform.Translate(belt.forward * _meterPerSecond * Time.deltaTime);
    }
}
