using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_02 : ContentScript {
    
    private TargetController _targetCon;

    private List<Target> _targets = new List<Target>();

    private DoorActivation _door;
    private Window _window;
    
    public float WindowTimer;

    private float _windowTime = 0;

    private bool _windowIsOpen = false;

    void Start ()
    {
        _targetCon = GetComponentInChildren<TargetController>();
        _targetCon.AllTargetsDestroyed += LevelEnd;
        _door = GetComponentInChildren<DoorActivation>();
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
                _windowIsOpen = false;
                StartCoroutine(_window.CloseWindow());
                StartCoroutine(StopTargets());
            }
        }

    }

    private void StartTargets()
    {
        _windowIsOpen = true;
        _targetCon.spawnTargets();

        for (int i = 0; i < _targetCon.transform.childCount; i++)
        {
            if (_targetCon.transform.GetChild(i).transform.GetComponent<Target>() != null)
            {
                _targets.Add(_targetCon.transform.GetChild(i).transform.GetComponent<Target>());
            }
        }
    }
    
    private IEnumerator StopTargets()
    {
        yield return new WaitForSeconds(2);
        _windowTime = 0;
        _targetCon.DestroyAllTargets();
        _targets.Clear();
    }

    private void LevelEnd()
    {
        _door.OpenDoorFromButton();
    }

    public override IEnumerator Setup()
    {
        return base.Setup();

        //DOSTUFF
    }
}
