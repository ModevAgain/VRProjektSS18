using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using DG.Tweening;

public class LeverPlane : MonoBehaviour {

    private float _minPos = 0.186f;
    private float _maxPos = 2.2f;
    
    public Transform ControlledPlane;

    // Use this for initialization
    void Start () {

        VRTK_Lever lever = GetComponent<VRTK_Lever>();
        lever.ValueChanged += LeverRemote_ValueChanged;
    }

    private void LeverRemote_ValueChanged(object sender, Control3DEventArgs e)
    {
        float resPos = e.normalizedValue / 100;

        resPos = _minPos + resPos * (_maxPos - _minPos);

        ControlledPlane.DOLocalMoveY(resPos,0);
    }


}
