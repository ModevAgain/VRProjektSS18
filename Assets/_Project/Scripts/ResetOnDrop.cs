using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using DG.Tweening;


public class ResetOnDrop : MonoBehaviour {

    private VRTK_InteractableObject _interactable;
    private Vector3 _startPos;
    private Quaternion _startRot;
    private Vector3 _startScale;
    private MeshRenderer _ren;
    private ReferenceManager _refMan;

    // Use this for initialization
    void Start () {

        _startPos = transform.position;
        _startRot = transform.rotation;
        _startScale = transform.lossyScale;
        _interactable = GetComponent<VRTK_InteractableObject>();
        _ren = GetComponent<MeshRenderer>();
        if (_ren == null)
            _ren = GetComponentInChildren<MeshRenderer>();
        _refMan = FindObjectOfType<ReferenceManager>();

	}


    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "floor")
        {
            if (!_interactable.IsGrabbed())
            {
                StartCoroutine(DissolveAndReset());
            }
        }
    }


    private IEnumerator DissolveAndReset()
    {
        _interactable.enabled = false;


        Tween dissolver;

        if (_ren != null)
        {
            _ren.material = _refMan.DissolveMat;

            _ren.allowOcclusionWhenDynamic = false;

            dissolver = _ren.material.DOFloat(1, "_DissolveIntensity", 1.2f);

            yield return dissolver.WaitForCompletion();
        }

        transform.position = _startPos;
        transform.rotation = _startRot;
        transform.localScale = _startScale;
        
        if(_ren != null)
        {
            //_ren.allowOcclusionWhenDynamic = true;
            dissolver = _ren.material.DOFloat(0, "_DissolveIntensity", 1.2f);

            yield return dissolver.WaitForCompletion();
        }


        _interactable.enabled = true;        
    }
}
