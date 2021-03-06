using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathMover : MonoBehaviour
{
    [SerializeField] List<Waypoints> _path = new List<Waypoints>();
    [SerializeField] [Range(0f, 5f)] float _speedMovement = 1f;
    //[SerializeField] float _waitTime = 1f;

    Enemy _enemy;

    void OnEnable()
    {
        FindPath();
        MoveEnemyToStartPosition();
        StartCoroutine(MoveToNextWaypoint());
    }

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void FindPath() 
    {
        _path.Clear();

        GameObject _parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform _child in _parent.transform)
        {
            Waypoints _waypoints = _child.GetComponent<Waypoints>();
            if ( _waypoints != null)
            {
                _path.Add(_waypoints);
            }
        }
    }
    
    void MoveEnemyToStartPosition()
    {
        Vector3 _startPosition = _path[0].transform.position;
        transform.position = _startPosition;
    }

    public void SetNewSpeed(float _newSpeed)
    {
        _speedMovement = _newSpeed;
    }

    void FinishPath()
    {
        _enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator MoveToNextWaypoint()
    {
        foreach(Waypoints _waypoint in _path)
        {
            Vector3 _startPosition = transform.position;
            Vector3 _endPosition = _waypoint.transform.position;
            float _travelPercent = 0f;

            transform.LookAt(_endPosition);

            while(_travelPercent < 1f)
            {
                _travelPercent += Time.deltaTime * _speedMovement;
                transform.position = Vector3.Lerp(_startPosition, _endPosition, _travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
