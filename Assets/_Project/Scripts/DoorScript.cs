using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorScript : MonoBehaviour {

    public float Y_Offset;

    private bool _isOpen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDoor()
    {

        if (_isOpen)
            return;

        Debug.Log("gunzt");
        _isOpen = true;

        transform.DOLocalMoveY(transform.localPosition.y - Y_Offset, 0.5f).OnComplete(() => Debug.Log("finished"));
    }

}
