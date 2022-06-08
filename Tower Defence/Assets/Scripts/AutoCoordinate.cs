using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class AutoCoordinate : MonoBehaviour
{
    TextMeshPro _label;
    Vector2Int _coordinates = new Vector2Int();

    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            ObjectNameUpdate();
        }
    }

    private void ObjectNameUpdate()
    {
        transform.parent.name = _coordinates.ToString();
    }

    private void DisplayCoordinates()
    {
        _coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        _coordinates.y = Mathf.RoundToInt(transform.parent.position.z);

        _label.text = _coordinates.x + "," + _coordinates.y;
    }
}
