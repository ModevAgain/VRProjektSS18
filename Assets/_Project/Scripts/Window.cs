using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Window : MonoBehaviour {

    private Material _windowMat;

    private bool _windowOpended = false;

    public float WindowCounter;
    private float _counter;

    public delegate void WindowOpened();
    public WindowOpened WindowIsOpen;

	// Use this for initialization
	void Start () {
        _windowMat = GetComponent<MeshRenderer>().material;
        _windowMat.DOFloat(0, "_Level", 0);
	}
	
    void Update()
    {
        //if (_windowOpended)
        //{
        //    _counter += Time.deltaTime;
        //    if (_counter >= WindowCounter)
        //    {
        //        _windowOpended = false;
        //        _counter = 0;
        //        StartCoroutine(CloseWindow());
        //    }
        //}
    }
    
    public void OnButtonPush()
    {
        if (!_windowOpended)
        {
            _windowOpended = true;
            StartCoroutine(OpenWindow());
        }
    }

    private IEnumerator OpenWindow()
    {
        Debug.Log("Open Window");
        Tween _openWindow = _windowMat.DOFloat(1, "_Level", 1);
        if (WindowIsOpen != null)
        {
            WindowIsOpen();
        }
        yield return _openWindow.WaitForCompletion();
        
    }

    public IEnumerator CloseWindow()
    {
        Debug.Log("Close Window");

        Tween _closeWindow = _windowMat.DOFloat(0, "_Level", 1);

        yield return _closeWindow.WaitForCompletion();
        _windowOpended = false;
    }

}
