using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour {
    
    TargetController targetCon;

    private float _startPos;
    private float _maxMoveRange;
    
	// Use this for initialization
	void Start () {
        targetCon = GetComponentInParent<TargetController>();

        _startPos = transform.parent.position.x;
        _maxMoveRange = _startPos + 8;

        MoveTarget();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MoveTarget()
    {
        if (targetCon.MoveY)
            transform.DOMoveY(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
        else if (targetCon.MoveX)
            transform.DOMoveY(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
        else if (targetCon.MoveZ)
            transform.DOMoveZ(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            targetCon.DestroyTarget(gameObject);
        }     
    }

}
