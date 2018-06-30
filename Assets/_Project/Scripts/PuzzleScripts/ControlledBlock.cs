using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using VRTK;
using Oculus;

public class ControlledBlock : ControlledObject
{
    public float Max;
    public float Min;

    public VRTK_Control.Direction Axis;

    public Vector3 StartPos;
    public float DesiredPos;

    public float DesiredPosThreshold;

    [SerializeField]
    private float _calculatedPos;

    [SerializeField]
    private bool _isInPlace;

    private ReferenceManager _refs;

    private void Awake()
    {
        Selector = GetComponentInChildren<ParticleSystem>();
        _refs = FindObjectOfType<ReferenceManager>();
        
    }

    public void Start()
    {
        transform.DOLocalMove(StartPos,0);
    }

    private void Update()
    {
        if (_isInPlace)
            return;

        if(Controller != null)
        {
            if (_calculatedPos > DesiredPos - DesiredPosThreshold && _calculatedPos < DesiredPos + DesiredPosThreshold)
            {
                VRTK_ControllerHaptics.TriggerHapticPulse(Controller, 1);
            }
        }
    }

    public override void MoveToNormedPos(float pos)
    {
        if (_isInPlace)
            return;

        pos = 1 - pos;

        _calculatedPos = Min + pos * (Max - Min);

        if(Axis == VRTK_Control.Direction.y)
            transform.DOLocalMoveY(_calculatedPos, 0);
        else if(Axis == VRTK_Control.Direction.x)
            transform.DOLocalMoveX(_calculatedPos, 0);
        else if (Axis == VRTK_Control.Direction.z)
            transform.DOLocalMoveZ(_calculatedPos, 0);

       
    }

    public override bool IsControlledObjectOnTarget()
    {


        if (_calculatedPos > DesiredPos - DesiredPosThreshold && _calculatedPos < DesiredPos + DesiredPosThreshold)
        {
            _isInPlace = true;
            SnapToDesiredPos();
            return true;
        }
        else return false;
    }

    private void SnapToDesiredPos()
    {
        if (Axis == VRTK_Control.Direction.y)
            transform.DOLocalMoveY(DesiredPos, 0);
        else if (Axis == VRTK_Control.Direction.x)
            transform.DOLocalMoveX(DesiredPos, 0);
        else if (Axis == VRTK_Control.Direction.z)
            transform.DOLocalMoveZ(DesiredPos, 0);
    }
}


public abstract class ControlledObject : MonoBehaviour
{
    public ParticleSystem Selector;

    public abstract void MoveToNormedPos(float pos);

    public abstract bool IsControlledObjectOnTarget();

    public VRTK_ControllerReference Controller;
}
