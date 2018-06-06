using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour {
    
    private TargetController _targetCon;

    private float _startPos;
    private float _maxMoveRange;
    
	// Use this for initialization
	void Start () {
        _targetCon = GetComponentInParent<TargetController>();

        //_startPos = transform.parent.position.x;
        _startPos = transform.position.x;


        _maxMoveRange = _startPos + 8;

        MoveTarget();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MoveTarget()
    {
        if (_targetCon.MoveY)
            transform.DOMoveY(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
        else if (_targetCon.MoveX)
            transform.DOMoveX(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
        else if (_targetCon.MoveZ)
            transform.DOMoveZ(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            _targetCon.DestroyTarget(gameObject);
        }     
    }

}
