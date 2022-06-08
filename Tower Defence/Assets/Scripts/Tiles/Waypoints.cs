using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] GameObject _tower;
    [SerializeField] bool _isPlaceable;
    public bool _IsPlaceable { get { return _isPlaceable; } }

    void OnMouseDown()
    {
        if(_isPlaceable)
        {
            Instantiate(_tower, transform.position, Quaternion.identity);
            _isPlaceable = false;
        }
    }
}
