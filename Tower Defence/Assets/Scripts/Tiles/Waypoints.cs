using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] Tower _tower;
    [SerializeField] bool _isPlaceable;
    public bool _IsPlaceable { get { return _isPlaceable; } }

    void OnMouseDown()
    {
        if(_isPlaceable)
        {
            bool _isPlaced = _tower.CreateTower(_tower, transform.position);
            _isPlaceable = !_isPlaced;
        }
    }
}
