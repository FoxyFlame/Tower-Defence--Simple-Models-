using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class AutoCoordinate : MonoBehaviour
{
    [SerializeField] Color _mainColor = Color.black;
    [SerializeField] Color _blockedColor = Color.gray;

    TextMeshPro _label;
    Vector2Int _coordinates = new Vector2Int();

    Waypoints _waypoints;

    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        _label.enabled = false;
        _waypoints = GetComponentInParent<Waypoints>();
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            ObjectNameUpdate();
        }

        ChangeColorCordinates();
        ToogleLabels();
    }

    void ToogleLabels()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _label.enabled = !_label.IsActive();
        }
    }

    void ChangeColorCordinates()
    {
        if(_waypoints._IsPlaceable)
        {
            _label.color = _mainColor;
        }
        else
        {
            _label.color = _blockedColor;
        }
    }

    void ObjectNameUpdate()
    {
        transform.parent.name = _coordinates.ToString();
    }

    void DisplayCoordinates()
    {
        _coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        _coordinates.y = Mathf.RoundToInt(transform.parent.position.z);

        _label.text = _coordinates.x + "," + _coordinates.y;
    }
}
