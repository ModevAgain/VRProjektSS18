using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonChasers : MonoBehaviour {

    private Collider _col;


	// Use this for initialization
	void Start () {

        _col = GetComponent<Collider>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        _col.enabled = false;

        if (transform.localPosition.x == 0)
        {            
            transform.DOLocalMoveX(-2, 0.2f).OnComplete(() => _col.enabled = true);
        }
        else transform.DOLocalMoveX(0, 0.2f).OnComplete(() => _col.enabled = true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hands")
            Move();
    }
}
