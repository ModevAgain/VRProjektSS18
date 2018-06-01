using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorActivation : MonoBehaviour {

    public string AnimationName;
    public bool Ready = false;

    private bool _canAnimate = false;
    private Animator _animator;

    public delegate void DoorOpen();
    public DoorOpen doorOpening;

    public delegate void RoomFinished();
    public RoomFinished RoomHasFinished;

    private bool _isOpen = false;

	// Use this for initialization
	void Start () {

        _animator = GetComponentInParent<Animator>();

	}

	public void Open()
	{
        if (!Ready)
            return;
		if (!_canAnimate)
			return;
		if (_isOpen)
			return;

        if (doorOpening != null)
        {
            doorOpening();
        }

        _canAnimate = false;
		_isOpen = true;

		_animator.SetTrigger("Open");

	}

    public void OpenDoorFromButton()
    {
        if (Ready)
            return;
        Ready = true;
        _canAnimate = true;
        Open();
    }

	public void Close()
	{
        if (!Ready)
            return;
        if (!_canAnimate)
            return;
        if (!_isOpen)
			return;

		_isOpen = false;
		_animator.SetTrigger("Close");

		_canAnimate = true;

	}


    private void OnTriggerEnter(Collider other)
    {
        if(RoomHasFinished != null)
            RoomHasFinished();
    }

    private void OnTriggerExit(Collider other)
    {

			Close ();

    }
}
