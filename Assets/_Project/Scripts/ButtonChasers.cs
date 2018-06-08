using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using VRTK;

public class ButtonChasers : MonoBehaviour {

    private Collider _col;

    private VRTK_Button _btn;


	// Use this for initialization
	void Start () {

        _col = GetComponent<Collider>();
        _btn = GetComponentInChildren<VRTK_Button>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        _col.enabled = false;
        _btn.enabled = false;

        Tween t = null;


        if (transform.localPosition.x == 0)
        {
            t = transform.DOLocalMoveX(-2, 0.2f);
        }
        else t = transform.DOLocalMoveX(0, 0.2f);

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
