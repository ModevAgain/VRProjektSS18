﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorScript : MonoBehaviour {

    public float Y_Offset;

    private bool _isOpen;
    
    public delegate void DoorOpen();
    public DoorOpen doorOpening;


    public void OpenDoor()
    {

        if (_isOpen)
            return;

        if (doorOpening != null)
        {
            doorOpening();
        }

        _isOpen = true;

        transform.DOLocalMoveY(transform.localPosition.y - Y_Offset, 0.5f);
    }

}