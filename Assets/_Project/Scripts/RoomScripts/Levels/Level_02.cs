using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_02 : ContentScript {
    
    private TargetController _targetCon;

    private List<Target> _targets = new List<Target>();

    private DoorScript _door;
    private Window _window;
    
    public float WindowTimer;

    private float _windowTime = 0;

    private bool _windowIsOpen = false;

    void Start ()
    {
        _targetCon = GetComponentInChildren<TargetController>();
        _targetCon.AllTargetsDestroyed += LevelEnd;
        _door = Door.GetComponent<DoorScript>();
        _window = GetComponentInChildren<Window>();
        Debug.Log(_window);
        _window.WindowIsOpen += StartTargets;         
    }

    void Update()
    {
        if (_windowIsOpen)
        {
            _windowTime += Time.deltaTime;
            if (_windowTime >= WindowTimer)
            {
                _window.CloseWindow();
                StopTargets();
            }
        }

    }

    private void StartTargets()
    {
        _windowIsOpen = true;
        _targetCon.spawnTargets();

        //foreach (GameObject target in _targetCon.transform)
        //{
        //    _targets.Add(target.transform.GetComponent<Target>());
        //    Debug.Log(target.transform.name);
        //}

        for (int i = 0; i < _targetCon.transform.childCount; i++)
        {
            if (_targetCon.transform.GetChild(i).transform.GetComponent<Target>() != null)
            {
                _targets.Add(_targetCon.transform.GetChild(i).transform.GetComponent<Target>());
            }
        }
    }
    
    private void StopTargets()
    {
        _windowIsOpen = false;
        _windowTime = 0;
        StartCoroutine(_window.CloseWindow());
        _targetCon.DestroyAllTargets();
        _targets.Clear();
    }

    private void LevelEnd()
    {
        _door.OpenDoor();
    }

    public override IEnumerator Setup()
    {
        return base.Setup();

        //DOSTUFF
    }
}
