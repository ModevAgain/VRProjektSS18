using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorActivation : MonoBehaviour {

    public string AnimationName;

    private bool _canAnimate = true;
    private Animator _animator;

    private bool _isOpen = false;

	// Use this for initialization
	void Start () {

        _animator = GetComponentInParent<Animator>();

	}
	

    private void OnTriggerEnter(Collider other)
    {
        if (!_canAnimate)
            return;
        if (_isOpen)
            return;

        _canAnimate = false;
        _isOpen = true;

        _animator.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isOpen)
            return;

        _isOpen = false;
        _animator.SetTrigger("Close");

        _canAnimate = true;
    }
}
