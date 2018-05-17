using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PanelActivator : MonoBehaviour {

    public Collider ActivationCol;

    public Transform Pillars;
    public Transform Fields;
    public GameObject Tablet;
    public List<Transform> Tablet_Positions;

    public float Y_Offset;

    private bool _isActive;
    private List<Renderer> _rens;

	// Use this for initialization
	void Start () {

        Pillars.DOLocalMoveY(- Y_Offset,0);

        _rens = new List<Renderer>();

        foreach (var ren in Fields.GetComponentsInChildren<Renderer>())
        {
            _rens.Add(ren);
            ren.material.DOFade(0, 0);
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (_isActive)
            return;

        _isActive = true;

        ActivationCol.enabled = false;

        Pillars.DOLocalMoveY(0, 2).OnComplete(() =>
        {
            foreach (var ren in _rens)
            {
                ren.material.DOFade(1, 0.8f);
            }

            ActivateTablet(other.transform);
        });




    }

    public void ActivateTablet(Transform target)
    {
        float minDist = Int32.MaxValue;
        Transform result = target;

        

        foreach (var t_Pos in Tablet_Positions)
        {
            Vector3 dir = t_Pos.position - target.transform.position;
            float dist = dir.sqrMagnitude;
            if (dist < minDist)
            {
                minDist = dist;
                result = t_Pos;
            }            
        }

        Vector3 targetPos = result.localPosition;
        targetPos.y = -0.72f;


        GameObject TabletInstance = Instantiate(Tablet, transform.parent);

        TabletInstance.transform.localPosition = targetPos;
        TabletInstance.transform.rotation = result.rotation;

        TabletInstance.transform.DOLocalMoveY(0, 3f);

    }
}
