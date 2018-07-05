using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using VRTK;

public class ButtonChasers : ContentScript {

    public GameObject Quaffel; 

    public  Collider _col;

    public VRTK_Button _btn;

    public Transform ButtonT;

    private Vector3 initPos;

	// Use this for initialization
	void Start () {

        initPos = ButtonT.localPosition;

        
        
        Quaffel.GetComponent<MeshRenderer>().material.DOFloat(1, "_DissolveIntensity", 0);
        //Quaffel.GetComponent<Collider>().enabled = false;
        Quaffel.SetActive(false);

    }

    public override IEnumerator CloseConnectionToOldRoom()
    {
        yield return base.CloseConnectionToOldRoom();

        Quaffel.SetActive(true);

        yield return Quaffel.GetComponent<MeshRenderer>().material.DOFloat(0, "_DissolveIntensity", 1).WaitForCompletion();

        Quaffel.GetComponent<Collider>().enabled = true;
    }

    public void Move()
    {
        _col.enabled = false;
        _btn.enabled = false;

        Tween t = null;


        if (transform.localPosition.x == initPos.x)
        {
            t = transform.DOLocalMoveX(-1.9f, 0.2f);
        }
        else t = transform.DOLocalMoveX(initPos.x, 0.2f);

        t.OnComplete(() =>
        {
            _col.enabled = true;
            _btn.enabled = true;
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hands")
            Move();
    }
}
