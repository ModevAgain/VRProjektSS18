using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using VRTK;

public class ButtonChasers : MonoBehaviour {

    private Collider _col;

    private VRTK_Button _btn;

    private Vector3 initPos;

	// Use this for initialization
	void Start () {

        initPos = transform.localPosition;

        _col = GetComponent<Collider>();
        _btn = GetComponentInChildren<VRTK_Button>();

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
