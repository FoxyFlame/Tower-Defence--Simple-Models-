using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] bool _isPlaceable;

    private void OnMouseOver()
    {
        if(_isPlaceable)
        {
            Debug.Log(transform.name);
        }
    }
}
