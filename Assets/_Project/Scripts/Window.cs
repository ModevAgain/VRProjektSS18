using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Window : MonoBehaviour {

    private Material _windowMat;

    private bool _windowOpended = false;

    public float WindowCounter;
    private float _counter;
    private MeshCollider _collider;
    private Level_02 _lvlMan;

    public delegate void WindowOpened();
    public WindowOpened WindowIsOpen;

	// Use this for initialization
	void Start () {
        _lvlMan = GetComponentInParent<Level_02>();
        _collider = GetComponent<MeshCollider>();
        _windowMat = GetComponent<MeshRenderer>().material;
        _windowMat.DOFloat(0, "_Level", 0);
	}
	
    public void OnButtonPush()
    {
        if (!_windowOpended && !_lvlMan._levelFinished)
        {
            _windowOpended = true;
            StartCoroutine(OpenWindow());
        }
    }

    private IEnumerator OpenWindow()
    {
        Debug.Log("Open Window");
        Tween _openWindow= _windowMat.DOFloat(1, "_SliceAmount", 2);
        _collider.enabled = false;

        yield return _openWindow.WaitForCompletion();

        if (WindowIsOpen != null)
        {
            WindowIsOpen();
        }
    }

    public IEnumerator CloseWindow()
    {
        Debug.Log("Close Window");

        Tween _closeWindow = _windowMat.DOFloat(0, "_SliceAmount", 2);
        _collider.enabled = true;

        yield return _closeWindow.WaitForCompletion();
        _windowOpended = false;
    }

}
